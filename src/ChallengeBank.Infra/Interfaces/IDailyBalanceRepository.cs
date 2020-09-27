using ChallengeBank.Domain.Entities;
using System.Collections.Generic;

namespace ChallengeBank.Infra.Interfaces
{
    public interface IDailyBalanceRepository : IRepository<DailyBalance>
    {
        void AddRange(ICollection<DailyBalance> dailyBalances);
    }
}
