using ChallengeBank.Domain.Entities;
using System.Collections.Generic;

namespace ChallengeBank.Infra.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> GetByBankAccountId(long bankAccountId);
    }
}
