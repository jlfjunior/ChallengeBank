using ChallengeBank.Domain.Entities;

namespace ChallengeBank.Api.ViewModels
{
    public class CustomerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer Map()
        {
            return new Customer
            {
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}
