using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessObject.PhoBo.Models
{
    public class Concept
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(50, ErrorMessage = "The length of Name is less than 50 characters")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}