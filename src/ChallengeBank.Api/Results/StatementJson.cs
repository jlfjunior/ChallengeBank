using ChallengeBank.Domain.Entities;
using ChallengeBank.Domain.Enums;

namespace ChallengeBank.Api.Results
{
    public class StatementJson
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }

        public StatementJson() { }

        public StatementJson(Transaction transaction)
        {
            Id = transaction.Id;
            Amount = transaction.Amount;

            if (transaction.Type == TransactionType.Deposit)
                Type = "Deposito";
            else if (transaction.Type == TransactionType.Withdraw)
                Type = "Saque";
            else if (transaction.Type == TransactionType.BillPayment)
                Type = "Pagamento-conta";
            else if (transaction.Type == TransactionType.Interest)
                Type = "Juros";
        }
    }
}
