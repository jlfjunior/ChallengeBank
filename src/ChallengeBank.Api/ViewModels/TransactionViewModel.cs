using ChallengeBank.Domain.Entities;
using ChallengeBank.Domain.Enums;

namespace ChallengeBank.Api.ViewModels
{
    public class TransactionViewModel
    {
        public long BankAccountId { get; set; }
        public long BankAccountIdDestination { get; set; }
        public decimal Amount { get; set; }

        public Transaction MapToDeposit()
        {
            return new Transaction
            {
                BankAccountId = BankAccountId,
                Amount = Amount,
                Type = TransactionType.Deposit
            };
        }

        public Transaction MapToWithdraw()
        {
            return new Transaction
            {
                BankAccountId = BankAccountId,
                Amount = Amount,
                Type = TransactionType.Withdraw
            };
        }
    }
}
