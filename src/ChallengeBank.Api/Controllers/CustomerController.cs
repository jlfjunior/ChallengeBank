using ChallengeBank.Api.Filters;
using ChallengeBank.Api.ViewModels;
using ChallengeBank.Service.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
