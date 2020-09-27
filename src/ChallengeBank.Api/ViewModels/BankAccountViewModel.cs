using ChallengeBank.Domain.Entities;

namespace ChallengeBank.Api.ViewModels
{
    public class BankAccountViewModel
    {
        public int CustomerId { get; set; }
        public string BankBranch { get; set; }
        public string AccountNumber { get; set; }

        public BankAccount Map()
        {
            return new BankAccount
            {
                CustomerId = CustomerId,
                BankBranch = BankBranch,
                AccountNumber = AccountNumber
            };
        }
    }
}
