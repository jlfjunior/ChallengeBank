namespace ChallengeBank.Domain.Entities
{
    public class Transaction
    {
        public long Id { get; set; }
        public long BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
        public decimal Amount { get; set; }
    }
}
