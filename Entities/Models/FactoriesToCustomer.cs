using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShekelAPI.Entities.Models
{
    [Table("factoriesToCustomer")]
    public class FactoriesToCustomer
    {
        [ForeignKey("groupCode")]
        public int GroupCode { get; set; }
        [ForeignKey("factoryCode")]
        public int FactoryCode { get; set; }
        [ForeignKey("customerId")]

        [StringLength(9, ErrorMessage = "The {0} field must be a maximum of {1} characters.")]
        public string CustomerId { get; set; }
    }
}
