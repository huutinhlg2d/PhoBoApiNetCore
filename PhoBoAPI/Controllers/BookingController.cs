using AutoMapper;
using BussinessObject.PhoBo.DTO;
using BussinessObject.PhoBo.Models;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PhoBoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;
        private readonly IConfiguration _config;

        public BookingController(IMapper mapper, IRepositoryWrapper repository, IConfiguration configuration)
        {
            _mapper = mapper;
            _repository = repository;
            _config = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookingAsync([FromForm] CreateBooking createBooking)
        {
            Booking booking = _mapper.Map<Booking>(createBooking);
            _repository.Booking.Create(booking);
            await _repository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetAll()
        {
            return Ok(_repository.Booking.FindAll());
        }
    }
}
