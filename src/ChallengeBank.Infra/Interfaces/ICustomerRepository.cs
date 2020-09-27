using ChallengeBank.Domain.Entities;
using System.Collections.Generic;

namespace ChallengeBank.Infra.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetAll();
    }
}
