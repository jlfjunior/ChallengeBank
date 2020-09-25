using ChallengeBank.Domain.Entities;

namespace ChallengeBank.Api.ViewModels
{
    public class TransactionViewModel
    {
        public long BankAccountId { get; set; }
        public long BankAccountIdDestination { get; set; }
        public decimal Amount { get; set; }

        public Transaction Map()
        {
            return new Transaction
            {
                BankAccountId = BankAccountId,
                Amount = Amount
            };
        }
    }
}
