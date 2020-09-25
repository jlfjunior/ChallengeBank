using ChallengeBank.Domain.Entities;
using ChallengeBank.Infra.Interfaces;

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

        public void Update(Transaction entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
