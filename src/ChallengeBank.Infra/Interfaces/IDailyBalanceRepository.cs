using ChallengeBank.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ChallengeBank.Infra.Interfaces
{
    public interface IDailyBalanceRepository : IRepository<DailyBalance>
    {
        void AddRange(ICollection<DailyBalance> dailyBalances);
        IEnumerable<DailyBalance> GetDailyBalances(DateTime date);
    }
}
