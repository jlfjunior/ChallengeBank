using ChallengeBank.Domain.Entities;
using ChallengeBank.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeBank.Infra.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly Context _context;

        public TransactionRepository(Context context)
        {
            _context = context;
        }

        public void Add(Transaction entity)
        {
            _context.Transactions.Add(entity);
            _context.SaveChanges();
        }

        public Transaction Find(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Transaction> GetByBankAccountId(long bankAccountId)
        {
            return _context.Transactions.Where(x => x.BankAccountId == bankAccountId)
                .Include(x => x.BankAccount)
                .ToList();
        }

        public void Update(Transaction entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
