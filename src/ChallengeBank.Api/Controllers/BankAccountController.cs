using ChallengeBank.Api.Results;
using ChallengeBank.Api.ViewModels;
using ChallengeBank.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Create(BankAccountViewModel model)
        {
            var bankAccount = _bankAccountService.Create(model.Map());
            return new JsonResult(bankAccount);
        }

        [HttpPost, Route("deposit")]
        public async Task<IActionResult> Deposit(TransactionViewModel model)
        {
            var transaction = _transactionService.Deposit(model.MapToDeposit());

            return new JsonResult(transaction);
        }

        [HttpPost, Route("withdraw")]
        public async Task<IActionResult> Withdraw(TransactionViewModel model)
        {
            var transaction = _transactionService.WithdrawAndPayment(model.MapToWithdraw());

            return new JsonResult(transaction);
        }

        [HttpPost, Route("pay")]
        public async Task<IActionResult> Pay(PaymentViewModel model)
        {
            var transaction = _transactionService.WithdrawAndPayment(model.Map());

            return new JsonResult(transaction);
        }

        [HttpGet, Route("statements/{id}")]
        public async Task<IActionResult> Statements(long id)
        {
            var transactions = _transactionService.GetTransactions(id);

            return new BankAccountStatementJson(transactions.ToList());
        }

        [HttpPost, Route("remunerate")]
        public async Task<IActionResult> Remunerate()
        {
            _bankAccountService.RemunerateAccounts();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var bankAccounts = _bankAccountService.GetBankAccounts();

            return new JsonResult(bankAccounts);
        }
    }
}
