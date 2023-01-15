using System.ComponentModel.DataAnnotations;

namespace ShekelAPI.Entities.DTOs
{
    public class NewCustomerDto
    {
        [StringLength(9, ErrorMessage = "The {0} field must be a maximum of {1} characters.")]
        public string CustomerId { get; set; }
        [StringLength(50, ErrorMessage = "The {0} field must be a maximum of {1} characters.")]
        public string Name { get; set; }
        [StringLength(150, ErrorMessage = "The {0} field must be a maximum of {1} characters.")]
        public string Address { get; set; }
        [StringLength(50, ErrorMessage = "The {0} field must be a maximum of {1} characters.")]
        public string Phone { get; set; }
        [Range(1, 1000)]
        public int GroupCode { get; set; }
        public int FactoryCode { get; set; }
    }
}
