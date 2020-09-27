using ChallengeBank.Domain.Entities;
using ChallengeBank.Infra.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeBank.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChangesAsync();
        }

        public Customer Find(long id)
        {
            return _context.Customers.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
            _context.SaveChangesAsync();
        }
    }
}
