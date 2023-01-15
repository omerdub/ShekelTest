using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShekelAPI.Entities.Models
{
    [Table("factories")]
    public class Factory
    {
        [ForeignKey("groupCode")]
        public int GroupCode { get; set; }

        public int FactoryCode { get; set; }

        [StringLength(50, ErrorMessage = "The {0} field must be a maximum of {1} characters.")]
        public string FactoryName { get; set; }
    }
}
