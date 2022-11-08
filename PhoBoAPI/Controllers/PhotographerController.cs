using BussinessObject.PhoBo.Models;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoBoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotographerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public PhotographerController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        // Get api/<UserController>
        [HttpGet()]
        public List<Photographer> GetAllPhotographers()
        {
            List<Photographer> photographers = _repository.Photographer.FindAll().ToList();

            return photographers;
        }

        // Get api/<UserController>
        [HttpGet("id")]
        public Photographer GetAllPhotographerByID(int id)
        {
            Photographer photographers = _repository.Photographer.FindByID(id);
            return photographers;
        }
    }
}
