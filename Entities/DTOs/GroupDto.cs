using System.Collections.Generic;

namespace ShekelAPI.Entities.DTOs
{
    public class GroupDto
    {
        public int GroupCode { get; set; }
        public string GroupName { get; set; }
        public List<CustomerDto> Customers { get; set; }
    }
}
