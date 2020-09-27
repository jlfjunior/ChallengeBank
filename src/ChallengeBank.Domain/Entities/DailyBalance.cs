using System;

namespace ChallengeBank.Domain.Entities
{
    public class DailyBalance
    {
        public long Id { get; set; }
        public long BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
        public decimal Balance { get; set; }
        public decimal RemuneratedAmount { get; set; }
        public DateTime Date { get; set; }
    }
}
