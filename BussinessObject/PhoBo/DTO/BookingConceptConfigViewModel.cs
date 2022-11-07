using BussinessObject.PhoBo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.PhoBo.DTO
{
    public class BookingConceptConfigViewModel
    {
        public int Id { get; set; }
        public int PhotographerId { get; set; }
        public int ConceptId { get; set; }
        public Concept concept { get; set; }

        public string DurationConfig { get; set; }
    }
}
