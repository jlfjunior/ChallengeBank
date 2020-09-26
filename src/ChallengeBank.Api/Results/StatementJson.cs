using ChallengeBank.Domain.Entities;

namespace ChallengeBank.Api.Results
{
    public class StatementJson
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }

        public StatementJson() { }

        public StatementJson(Transaction transaction)
        {
            Id = transaction.Id;
            Amount = transaction.Amount;
        }
    }
}
