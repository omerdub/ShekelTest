using ShekelAPI.DAL.Data;
using ShekelAPI.Entities.DTOs;
using ShekelAPI.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShekelAPI.DAL.Repositories
{
    public class ShekelRepository : IShekelRepository
    {
        private readonly IShekelDbContext _context;

        public ShekelRepository(IShekelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GroupWithCustomersDto> GetGroupsWithCustomers()
        {
            List<GroupWithCustomersDto> list = new List<GroupWithCustomersDto>();
            foreach (var group in _context.Groups.ToList())
            {
                List<CustomerDto> usersList = new List<CustomerDto>();
                foreach (var factoriesToCustomer in _context.FactoriesToCustomers.ToList())
                {
                    if (factoriesToCustomer.GroupCode == group.GroupCode)
                    {
                        usersList.Add
                            (
                            new CustomerDto()
                                {
                                    CustomerId = factoriesToCustomer.CustomerId,
                                    Name = _context.Customers.First(u => u.CustomerId == factoriesToCustomer.CustomerId).Name
                                }
                            );
                    }
                }
                var newGroupWithCustomer = new GroupWithCustomersDto()
                {
                    GroupCode = group.GroupCode,
                    GroupName = group.GroupName,
                };

                if(usersList.Any())
                {
                    newGroupWithCustomer.Customers = usersList;
                }
                list.Add(newGroupWithCustomer);
            }
            return list;
        }

        public async Task<Customer> AddCustomer(NewCustomerDto newCustomer)
        {
            // Create new customer object and add it to the context
            var newCust = new Customer()
            {
                CustomerId = newCustomer.CustomerId,
                Name = newCustomer.Name,
                Address = newCustomer.Address,
                Phone = newCustomer.Phone
            };

            // Create new factoriesToCustomer object and add it to the context
            _context.FactoriesToCustomers.Add(new FactoriesToCustomer()
            {
                FactoryCode = newCustomer.FactoryCode,
                GroupCode = newCustomer.GroupCode,
                CustomerId = newCustomer.CustomerId
            }
            );

            _context.Customers.Add(newCust);
            await _context.SaveChangesAsync();
            return newCust;
        }
    }
}
