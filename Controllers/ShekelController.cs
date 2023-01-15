using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShekelAPI.DAL.Repositories;
using ShekelAPI.Entities.DTOs;
using ShekelAPI.Entities.Models;
using ShekelAPI.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShekelAPI.Controllers
{
    public class ShekelController : ControllerBase
    {
        private readonly IShekelRepository _repository;
        private readonly INewCustomerValidator<NewCustomerDto> _newCustomerValidator;
        private readonly ILogger _logger;

        public ShekelController(IShekelRepository repository, INewCustomerValidator<NewCustomerDto> newCustomerValidator, ILogger<ShekelController> logger)
        {
            _repository = repository;
            _newCustomerValidator = newCustomerValidator;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<GroupDto>> GetGroupsWithCustomers()
        {
            _logger.LogInformation("Getting all groups with customers...");
            try
            {
                var groups = _repository.GetGroupsWithCustomers();
                if (groups == null || !groups.Any())
                {
                    string error = "No Groups with Customers found";
                    _logger.LogWarning(error);
                    return NotFound(error);
                }
                _logger.LogInformation("Returning all groups with customers");
                return Ok(groups);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all groups with customers", ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddNewCustomer(NewCustomerDto newCustomer)
        {
            _logger.LogInformation("Adding a new customer...");
            try
            {
                var errors = _newCustomerValidator.Validate(newCustomer);
                if (errors.Any())
                {
                    _logger.LogWarning("Adding a new customer failed" ,errors);
                    return BadRequest(errors);
                }
                var customer = await _repository.AddCustomer(newCustomer);
                _logger.LogInformation("A new customer was added...");
                return CreatedAtAction(nameof(GetGroupsWithCustomers), new { id = customer.CustomerId }, customer);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while adding a new customer", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
