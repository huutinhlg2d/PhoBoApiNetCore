using BussinessObject.PhoBo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.PhoBo.DTO
{
    public class UserBooking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerName { get; set; }
        public int PhotographerId { get; set; }
        public string PhotographerName { get; set; }
        public string PhotographerEmail { get; set; }
        public string ConceptName { get; set; }
        public DateTime BookingDate { get; set; }
        public float BookingRate { get; set; }
        public float Duration { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        public BookingState State { get; set; }
    }
}
