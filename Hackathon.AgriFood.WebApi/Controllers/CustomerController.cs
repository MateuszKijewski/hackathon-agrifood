using Hackathon.AgriFood.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.WebApi.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet(ApiRoutes.Customer.Main)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var requestedCustomers = await _customerService.GetAllCustomers();

                return Ok(requestedCustomers);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
