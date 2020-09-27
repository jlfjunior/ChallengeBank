using ChallengeBank.Domain.Entities;
using ChallengeBank.Infra.Interfaces;
using System.Collections.Generic;
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

        public IEnumerable<BankAccount> GetBankAccountsAvailableForRemunerate()
        {
            return _context.BankAccounts.Where(x => x.Balance > 0).ToList();
        }

        public void Update(BankAccount entity)
        {
            _context.BankAccounts.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateRange(ICollection<BankAccount> bankAccounts)
        {
            _context.BankAccounts.AddRange(bankAccounts);
            _context.SaveChanges();
        }
    }
}
