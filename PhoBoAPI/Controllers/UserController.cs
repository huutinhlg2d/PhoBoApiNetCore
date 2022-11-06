using AutoMapper;
using BussinessObject.PhoBo.Models;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PhoBoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // Get api/<UserController>
        [HttpGet("id")]
        public User GetUserById(int id)
        {
            User user = _repository.User.FindByID(id);

            Debug.WriteLine($"{user.Email} {user.Password}");

            return user;
        }

        // Get api/<UserController>
        [HttpGet("role")]
        public List<User> GetUserByRole(UserRole role)
        {
            List<User> users = _repository.User.getUserByRole(role);

            //Debug.WriteLine($"{user.Email} {user.Password}");

            return users;
        }
    }
}
