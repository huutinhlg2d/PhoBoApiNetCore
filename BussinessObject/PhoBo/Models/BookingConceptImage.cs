using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessObject.PhoBo.Models
{
    public class BookingConceptImage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("BookingConceptConfig")]
        public int ConfigId { get; set; }
        public BookingConceptConfig Config { get; set; }
        public string ImageUrl { get; set; }
    }
}
