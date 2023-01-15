using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShekelAPI.Entities.Models
{
    [Table("groups")]
    public class Group
    {
        public int GroupCode { get; set; }

        [StringLength(150, ErrorMessage = "The {0} field must be a maximum of {1} characters.")]
        public string GroupName { get; set; }
    }
}
