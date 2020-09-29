using System.Collections.Generic;

namespace ChallengeBank.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<BankAccount> BankAccounts { get; set; }
    }
}
