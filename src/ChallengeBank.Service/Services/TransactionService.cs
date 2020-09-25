using ChallengeBank.Domain.Entities;
using ChallengeBank.Infra.Interfaces;

namespace ChallengeBank.Service.Services
{
    public class TransactionService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IBankAccountRepository bankAccountRepository, ITransactionRepository transactionRepository)
        {
            _bankAccountRepository = bankAccountRepository;
            _transactionRepository = transactionRepository;
        }

        public Transaction Deposit(Transaction transaction)
        {
            var bankAccount = _bankAccountRepository.Find(transaction.BankAccountId);

            if (bankAccount != null)
                bankAccount.Balance += transaction.Amount;

            _transactionRepository.Add(transaction);
            _bankAccountRepository.Update(bankAccount);

            return transaction;
        }

        public Transaction Withdraw(Transaction transaction)
        {
            var bankAccount = _bankAccountRepository.Find(transaction.BankAccountId);

            if (bankAccount != null && bankAccount.Balance > transaction.Amount)
                bankAccount.Balance -= transaction.Amount;

            _transactionRepository.Add(transaction);
            _bankAccountRepository.Update(bankAccount);

            return transaction;
        }
    }
}
