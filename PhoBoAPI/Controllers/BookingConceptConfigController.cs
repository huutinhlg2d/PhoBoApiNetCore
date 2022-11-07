using AutoMapper;
using BussinessObject.PhoBo.DTO;
using BussinessObject.PhoBo.Models;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PhoBoAPI.Attribute.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoBoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingConceptConfigController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;
        private readonly IConfiguration _config;

        public BookingConceptConfigController(IMapper mapper, IRepositoryWrapper repository, IConfiguration configuration)
        {
            _mapper = mapper;
            _repository = repository;
            _config = configuration;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookingConceptConfig>> GetAll()
        {
            return Ok(_repository.BookingConceptConfig.FindAll());
        }

        [HttpGet("photographer/{id}")]
        public ActionResult<IEnumerable<BookingConceptConfigViewModel>> Get(int id)
        {
            if (!PhotographerExists(id)) return NotFound();

            var concepts = _repository.BookingConceptConfig.FindByPhotographerId(id);
            var conceptsViewModel = _mapper.Map<List<BookingConceptConfigViewModel>>(concepts);

            return Ok(conceptsViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<BookingConceptConfigViewModel>> AddAsync([FromForm] CreateBookingConceptConfig config)
        {
            if (!PhotographerExists(config.PhotographerId))
                return NotFound("Photographer does not exist");

            if (PhotographerConceptExist(config.PhotographerId, config.ConceptId))
            {
                return BadRequest("Configuration exists");
            }

            var addConfig = _mapper.Map<BookingConceptConfig>(config);

            _repository.BookingConceptConfig.Create(addConfig);
            await _repository.SaveAsync();

            _repository.BookingConceptConfig.LoadConcept(addConfig);

            return Ok(_mapper.Map<BookingConceptConfigViewModel>(addConfig));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<BookingConceptConfigViewModel>>> DeleteAsync(int id)
        {
            var concept = _repository.BookingConceptConfig.FindByID(id);
            if (concept == null) return NotFound();

            _repository.BookingConceptConfig.Delete(concept);
            await _repository.SaveAsync();
            return Ok(_mapper.Map<BookingConceptConfigViewModel>(concept));
        }

        private bool PhotographerExists(int photographerId) {
            return _repository.Photographer.FindByID(photographerId) != null;
        }

        private bool PhotographerConceptExist(int photographerId, int conceptId)
        {
            bool result = _repository.BookingConceptConfig
                .Exists(bcc => bcc.PhotographerId == photographerId && bcc.ConceptId == conceptId);
            return result;
        }
    }
}
