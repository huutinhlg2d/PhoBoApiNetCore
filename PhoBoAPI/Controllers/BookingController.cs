using AutoMapper;
using BussinessObject.PhoBo.DTO;
using BussinessObject.PhoBo.Models;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet("photographer/{id}")]
        public IActionResult getAllBookingByPhotographerId(int id)
        {
            List<Booking> bookingList = _repository.Booking.findAllBookingByCondition(booking => (int)(booking.PhotographerId) == id).ToList();
            if (bookingList.Count == 0)
            {
                return NotFound("Not Found");
            }
            //IEnumerable<UserBooking> userBookingList = bookingList.Select(b => _mapper.Map<UserBooking>(b));
            List<UserBooking> userBookingList = _mapper.Map<List<UserBooking>>(bookingList);
            return Ok(userBookingList);
        }

        [HttpGet("customer/{id}")]
        public IActionResult getAllBookingByCustomerId(int id)
        {
            List<Booking> bookingList = _repository.Booking.findAllBookingByCondition(booking => (int)(booking.CustomerId) == id).ToList();
            if (bookingList.Count == 0)
            {
                return NotFound("Not Found");
            }
            //IEnumerable<UserBooking> userBookingList = bookingList.Select(b => _mapper.Map<UserBooking>(b));
            List<UserBooking> userBookingList = _mapper.Map<List<UserBooking>>(bookingList);
            return Ok(userBookingList);
        }
    }
}
