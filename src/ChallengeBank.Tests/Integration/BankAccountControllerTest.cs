using ChallengeBank.Api.ViewModels;
using ChallengeBank.Domain.Entities;
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

            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
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
    }
}
