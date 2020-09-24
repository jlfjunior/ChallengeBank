using System;

namespace ChallengeBank.Domain.Entities
{
    public class BankAccount
    {
        public long Id { get; set; }
        public string BankBranch { get; set; }
        public string AccountNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Balance { get; set; }
    }
}
