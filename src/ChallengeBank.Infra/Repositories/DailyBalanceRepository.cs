using ChallengeBank.Domain.Entities;
using ChallengeBank.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeBank.Infra.Repositories
{
    public class DailyBalanceRepository : IDailyBalanceRepository
    {
        private readonly Context _context;

        public DailyBalanceRepository(Context context)
        {
            _context = context;
        }

        public void Add(DailyBalance entity)
        {
            _context.DailyBalances.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(ICollection<DailyBalance> dailyBalances)
        {
            _context.DailyBalances.AddRange(dailyBalances);
            _context.SaveChanges();
        }

        public DailyBalance Find(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DailyBalance> GetDailyBalances(DateTime date)
        {
            return _context.DailyBalances.Where(x => x.Date.Date == date.Date).ToList();
        }

        public void Update(DailyBalance entity)
        {
            throw new NotImplementedException();
        }
    }
}
