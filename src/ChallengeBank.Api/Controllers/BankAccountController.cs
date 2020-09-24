using Microsoft.AspNetCore.Mvc;

namespace ChallengeBank.Api.Controllers
{
    [ApiController]
    [Route("api/bank-accounts")]
    public class BankAccountController : ControllerBase
    {
        public BankAccountController()
        {
        }

        [HttpPost]
        public IActionResult WithDraw()
        {

            return Ok();
        }
    }
}
