using ChallengeBank.Domain.Entities;
using ChallengeBank.Domain.Enums;

namespace ChallengeBank.Api.ViewModels
{
    public class PaymentViewModel
    {
        public long BankAccountId { get; set; }
        public decimal Amount { get; set; }

        public Transaction Map()
        {
            return new Transaction
            {
                BankAccountId = BankAccountId,
                Amount = Amount,
                Type = TransactionType.BillPayment
            };
        }
    }
}
