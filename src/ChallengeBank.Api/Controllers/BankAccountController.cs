using ChallengeBank.Api.ViewModels;
using ChallengeBank.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeBank.Api.Controllers
{
    [ApiController]
    [Route("api/bank-accounts")]
    public class BankAccountController : ControllerBase
    {
        private readonly BankAccountService _bankAccountService;
        private readonly TransactionService _transactionService;

        public BankAccountController(BankAccountService bankAccountService, TransactionService transactionService)
        {
            _bankAccountService = bankAccountService;
            _transactionService = transactionService;
        }

        [HttpPost]
        public IActionResult Create(BankAccountViewModel model)
        {
            var bankAccount = _bankAccountService.Create(model.Map());
            return Accepted(bankAccount);
        }

        [HttpPost, Route("deposit")]
        public IActionResult Deposit(TransactionViewModel model)
        {
            var transaction = _transactionService.Deposit(model.Map());

            return Ok(transaction);
        }

        [HttpPost, Route("withdraw")]
        public IActionResult Withdraw(TransactionViewModel model)
        {
            var transaction = _transactionService.Withdraw(model.Map());

            return Ok(transaction);
        }
    }
}
