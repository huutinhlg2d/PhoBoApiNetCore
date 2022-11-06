using AutoMapper;
using BussinessObject.PhoBo.Models;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace PhoBoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotographerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;
        private readonly IConfiguration _config;

        public PhotographerController(IMapper mapper, IRepositoryWrapper repository, IConfiguration configuration)
        {
            _mapper = mapper;
            _repository = repository;
            _config = configuration;
        }

        [HttpGet("{id}")]
        public ActionResult<Photographer> Get(int id)
        {
            return Ok(_repository.Photographer.FindByID(id));
        }
    }
}
