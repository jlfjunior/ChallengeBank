using ChallengeBank.Domain.Entities;
using ChallengeBank.Infra.Interfaces;
using System.Linq;

namespace ChallengeBank.Infra.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly Context _context;

        public BankAccountRepository(Context context)
        {
            _context = context;
        }

        public void Add(BankAccount entity)
        {
            _context.BankAccounts.Add(entity);
            _context.SaveChanges();
        }

        public BankAccount Find(long id)
        {
            return _context.BankAccounts.SingleOrDefault(x => x.Id == id);
        }

        public void Update(BankAccount entity)
        {
            _context.BankAccounts.Update(entity);
            _context.SaveChanges();
        }
    }
}
