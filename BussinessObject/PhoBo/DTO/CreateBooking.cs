using BussinessObject.PhoBo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.PhoBo.DTO
{
    public class CreateBooking
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int PhotographerId { get; set; }
        [Required]
        public int ConceptId { get; set; }
        [Required]
        public DateTime BookingDay { get; set; }
        [Required]
        public string BookingTime { get; set; }
        [Required]
        public float Duration { get; set; }
        [Required]
        public string Location { get; set; }
        public string Note { get; set; }
        public DateTime GetBookingDate()
        {
            int[] times = BookingTime.Split(":").Select(time => int.Parse(time)).ToArray();
            int timeMillis = times[0] * 60 * 60 * 1000 + times[1] * 60 * 1000;
            DateTime bookingDate = DateTime.ParseExact(BookingDay.ToString("dd/MM/yyyy") + " " + BookingTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture); ;
            return bookingDate;
        }
    }
}
