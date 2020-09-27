using ChallengeBank.Api.Results;
using ChallengeBank.Api.ViewModels;
using ChallengeBank.Domain.Entities;
using ChallengeBank.Tests.Extensions;
using ChallengeBank.Tests.Fakes;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ChallengeBank.Tests.Integration
{
    public class BankAccountControllerTest : IClassFixture<StartupFake>
    {
        private const string _URL = "api/bank-accounts";
        private readonly StartupFake _startup;

        public BankAccountControllerTest(StartupFake startup)
        {
            _startup = startup;
        }

        [Fact]
        public async Task ShouldCreate()
        {
            var customer = new Customer
            {
                FirstName = "Olivia",
                LastName = "Melo"
            };

            _startup.DbContext.Customers.Add(customer);
            await _startup.DbContext.SaveChangesAsync();

            var model = new BankAccountViewModel
            {
                CustomerId = customer.Id
            };

            var response = await _startup.CreateClient().PostAsJsonAsync(_URL, model);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ShouldDepositCash()
        {
            var bankAccount = new BankAccount
            {
                AccountNumber = "12345-0",
                BankBranch = "1233"
            };
            
            _startup.DbContext.BankAccounts.Add(bankAccount);
            
            var model = new TransactionViewModel
            {
                BankAccountId = bankAccount.Id,
                Amount = 200
            };

            await _startup.DbContext.SaveChangesAsync();

            var response = await _startup.CreateClient().PostAsJsonAsync(_URL + "/deposit", model);

            await _startup.DbContext.Entry<BankAccount>(bankAccount).ReloadAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(200, bankAccount.Balance);
        }

        [Fact]
        public async Task ShouldWithDrawCash()
        {
            var bankAccount = new BankAccount
            {
                AccountNumber = "12345-0",
                BankBranch = "1233",
                Balance = 300
            };
            
            _startup.DbContext.BankAccounts.Add(bankAccount);

            var model = new TransactionViewModel
            {
                BankAccountId = bankAccount.Id,
                Amount = 200
            };

            await _startup.DbContext.SaveChangesAsync();

            var response = await _startup.CreateClient().PostAsJsonAsync(_URL + "/withdraw", model);
            
            await _startup.DbContext.Entry<BankAccount>(bankAccount).ReloadAsync();
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(100, bankAccount.Balance);
        }

        [Fact]
        public async Task ShouldPay()
        {
            var bankAccount = new BankAccount
            {
                AccountNumber = "12345-0",
                BankBranch = "1233",
                Balance = 300
            };

            _startup.DbContext.BankAccounts.Add(bankAccount);

            var model = new PaymentViewModel
            {
                BankAccountId = bankAccount.Id,
                Amount = 150
            };

            await _startup.DbContext.SaveChangesAsync();

            var response = await _startup.CreateClient().PostAsJsonAsync(_URL + "/withdraw", model);

            await _startup.DbContext.Entry<BankAccount>(bankAccount).ReloadAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(150, bankAccount.Balance);
        }

        [Fact]
        public async Task ShouldGetStatements()
        {
            var bankAccount = new BankAccount
            {
                AccountNumber = "12345-0",
                BankBranch = "1233",
                Balance = 300
            };

            _startup.DbContext.BankAccounts.Add(bankAccount);

            var transaction1 = new Transaction
            {
                BankAccountId = bankAccount.Id,
                Type = Domain.Enums.TransactionType.Deposit
            };

            var transaction2 = new Transaction
            {
                BankAccountId = bankAccount.Id,
                Type = Domain.Enums.TransactionType.Withdraw
            };

            var transaction3 = new Transaction
            {
                BankAccountId = bankAccount.Id,
                Type = Domain.Enums.TransactionType.BillPayment
            };

            _startup.DbContext.Transactions.AddRange(transaction1, transaction2, transaction3);
            await _startup.DbContext.SaveChangesAsync();

            var response = await _startup.CreateClient().GetAsync(_URL + $"/statements/{bankAccount.Id}");
            var json = await response.Content.ReadAsJsonAsync<BankAccountStatementJson>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(bankAccount.Id, json.BankAccountId);
            Assert.Equal(3, json.Statements.Count);
        }

        [Fact]
        public async Task ShouldRemunerateAccounts()
        {
            var bankAccount1 = new BankAccount
            {
                Customer = new Customer { },
                Balance = 100
            };

            var bankAccount2 = new BankAccount
            {
                Customer = new Customer { },
                Balance = 200
            };

            var bankAccount3 = new BankAccount
            {
                Customer = new Customer { },
                Balance = 300
            };

            var bankAccount4 = new BankAccount
            {
                Customer = new Customer { },
                Balance = 0
            };

            var bankAccount5 = new BankAccount
            {
                Customer = new Customer { },
                Balance = 0
            };

            _startup.DbContext.BankAccounts.AddRange(bankAccount1, bankAccount2, bankAccount3, bankAccount4, bankAccount5);
            await _startup.DbContext.SaveChangesAsync();

            var response = await _startup.CreateClient().PostAsync(_URL + "/remunerate", null);
            //_startup.DbContext.Entry<BankAccount>(bankAccount1).Reload();
            //_startup.DbContext.Entry<BankAccount>(bankAccount2).Reload();
            //_startup.DbContext.Entry<BankAccount>(bankAccount3).Reload();
            //_startup.DbContext.Entry<BankAccount>(bankAccount4).Reload();
            //_startup.DbContext.Entry<BankAccount>(bankAccount5).Reload();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
