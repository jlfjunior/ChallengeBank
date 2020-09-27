using ChallengeBank.Api.Filters;
using ChallengeBank.Api.ViewModels;
using ChallengeBank.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChallengeBank.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost, Auth]
        public IActionResult Create(CustomerViewModel model)
        {
            var customer = _customerService.Create(model.Map());
            return Accepted(customer);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var customers = _customerService.GetCustomers();

            return new JsonResult(customers);
        }
    }
}
