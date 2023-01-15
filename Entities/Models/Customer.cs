using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShekelAPI.Entities.Models
{
    [Table("customers")]
    public class Customer
    {
        [StringLength(9, ErrorMessage = "The {0} field must be a maximum of {1} characters.")]
        public string CustomerId { get; set; }

        [StringLength(50, ErrorMessage = "The {0} field must be a maximum of {1} characters.")]
        public string Name { get; set; }

        [StringLength(150, ErrorMessage = "The {0} field must be a maximum of {1} characters.")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "The {0} field must be a maximum of {1} characters.")]
        public string Phone { get; set; }
    }
}
