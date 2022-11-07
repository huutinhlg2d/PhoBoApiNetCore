using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.PhoBo.DTO
{
    public class CreateBookingConceptConfig
    {
        [Required]        
        public int PhotographerId { get; set; }
        [Required]
        public int ConceptId { get; set; }
        [Required]
        public string DurationConfig { get; set; }
    }
}
