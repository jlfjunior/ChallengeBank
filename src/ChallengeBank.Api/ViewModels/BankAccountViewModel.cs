using ChallengeBank.Domain.Entities;

namespace ChallengeBank.Api.ViewModels
{
    public class BankAccountViewModel
    {
        public int CustomerId { get; set; }

        public BankAccount Map()
        {
            return new BankAccount
            {
                CustomerId = CustomerId
            };
        }
    }
}
