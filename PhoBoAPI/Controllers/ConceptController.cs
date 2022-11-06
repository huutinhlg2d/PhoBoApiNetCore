using AutoMapper;
using BussinessObject.PhoBo.Models;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace PhoBoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;
        private readonly IConfiguration _config;

        public ConceptController(IMapper mapper, IRepositoryWrapper repository, IConfiguration configuration)
        {
            _mapper = mapper;
            _repository = repository;
            _config = configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Concept>> GetAll()
        {
            return Ok(_repository.Concept.FindAll());
        }
    }
}
