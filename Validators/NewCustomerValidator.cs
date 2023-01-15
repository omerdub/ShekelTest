using ShekelAPI.DAL.Data;
using ShekelAPI.Entities.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShekelAPI.Validators
{
    public class NewCustomerValidator : INewCustomerValidator<NewCustomerDto>
    {
        private readonly IShekelDbContext _context;
        public NewCustomerValidator(IShekelDbContext context)
        {
            _context = context;
        }
        public List<string> Validate(NewCustomerDto customer)
        {
            var errors = new List<string>();
            var context = new ValidationContext(customer);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(customer, context, results, true))
            {
                foreach (var validationResult in results)
                {
                    errors.Add(validationResult.ErrorMessage);
                }
            }

            if (_context.Customers.Any(c => c.CustomerId == customer.CustomerId))
            {
                errors.Add($"User with CustomerId '{customer.CustomerId}' already exists.");
            }

            if (!_context.Groups.Any(g => g.GroupCode == customer.GroupCode))
            {
                errors.Add($"Group with GroupCode '{customer.GroupCode}' does not exist.");
            }
            else
            {
                var factory = _context.Factories.FirstOrDefault(f => f.FactoryCode == customer.FactoryCode);
                if (factory == null)
                {
                    errors.Add($"Factory with FactoryCode '{customer.FactoryCode}' does not exist.");
                }
                else if (factory.GroupCode != customer.GroupCode)
                {
                    errors.Add($"Factory with FactoryCode '{customer.FactoryCode}' does not belong to the group with GroupCode '{customer.GroupCode}'.");
                }
            }
            return errors;
        }
    }
}
