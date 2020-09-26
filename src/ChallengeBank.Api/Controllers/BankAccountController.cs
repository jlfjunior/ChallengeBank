﻿using ChallengeBank.Api.Results;
using ChallengeBank.Api.ViewModels;
using ChallengeBank.Domain.Entities;
using ChallengeBank.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            var transaction = _transactionService.Withdraw(model.MapToWithdraw());

            return new JsonResult(transaction);
        }

        [HttpPost, Route("pay")]
        public async Task<IActionResult> Pay(PaymentViewModel model)
        {
            var transaction = _transactionService.Pay(model.Map());

            return new JsonResult(transaction);
        }

        [HttpGet, Route("statements/{id:long}")]
        public async Task<IActionResult> Statements(long id)
        {
            var transactions = _transactionService.GetTransactions(id);

            return new BankAccountStatementJson(transactions.ToList());
        }
    }
}
