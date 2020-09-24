using ChallengeBank.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeBank.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        public CustomerController() { }

        [HttpPost]
        public IActionResult Create(CustomerViewModel model)
        {
            return Accepted(model);
        }
    }
}
