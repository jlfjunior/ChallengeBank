using System;
using System.Collections.Generic;

namespace ChallengeBank.Domain.Entities
{
    public class BankAccount
    {
        public long Id { get; set; }
        public string BankBranch { get; set; }
        public string AccountNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<DailyBalance> DailyBalances { get; set; }
    }
}
