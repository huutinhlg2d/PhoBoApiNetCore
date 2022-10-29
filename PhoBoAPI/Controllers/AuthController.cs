using AutoMapper;
using BussinessObject.PhoBo.DTO;
using BussinessObject.PhoBo.Models;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoBoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;
        private readonly IConfiguration _config;

        public AuthController(IMapper mapper, IRepositoryWrapper repository, IConfiguration configuration)
        {
            _mapper = mapper;
            _repository = repository;
            _config = configuration;
        }


        // POST api/<AuthController>
        [HttpPost("register"), RequestSizeLimit(Int32.MaxValue)]    
        public void Register([FromForm] Register register)
        {
            User user = _mapper.Map<User>(register);

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), register.GetAvatarUrl());

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                register.AvatarFile.CopyToAsync(stream);
            }

            if (user.Role.Equals(UserRole.Customer))
            {
                Customer customer = _mapper.Map<Customer>(user);
                _repository.Customer.Create(customer);
            }
            else if (user.Role.Equals(UserRole.Photographer))
            {
                var photographer = _mapper.Map<Photographer>(user);
                photographer.Role = UserRole.PendingPhotographer;
                _repository.Photographer.Create(photographer);
            }

            _repository.Save();
        }

        // POST api/<AuthController>
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            User user = _mapper.Map<User>(login);

            User loginUser = _repository.User.Login(login.Email, login.Password);

            Debug.WriteLine($"{login.Email} {login.Password}");

            if(loginUser == null)
            {
                return Unauthorized("Login fail!");
            }

            var tokenString = BuildToken(user);

            return Ok(new { user = loginUser, token = tokenString});
        }

        private string BuildToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
