using ShekelAPI.Entities.DTOs;
using ShekelAPI.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShekelAPI.DAL.Repositories
{
    public interface IShekelRepository
    {
        public IEnumerable<GroupWithCustomersDto> GetGroupsWithCustomers();
        public Task<Customer> AddCustomer(NewCustomerDto newCustomer);
    }
}
