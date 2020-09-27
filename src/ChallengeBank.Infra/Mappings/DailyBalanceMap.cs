using ChallengeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeBank.Infra.Mappings
{
    public static class DailyBalanceMap
    {
        public static void Map(this EntityTypeBuilder<DailyBalance> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id);
            entity.Property(x => x.BankAccountId);
            entity.Property(x => x.Date);
            entity.Property(x => x.Balance);
            entity.Property(x => x.RemuneratedAmount);
        }
    }
}
