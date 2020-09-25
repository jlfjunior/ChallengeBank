using ChallengeBank.Domain.Entities;
using ChallengeBank.Infra.Interfaces;

namespace ChallengeBank.Service.Services
{
    public class BankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public BankAccount Create(BankAccount bankAccount)
        {
            _bankAccountRepository.Add(bankAccount);

            return bankAccount;
        }
    }
}
