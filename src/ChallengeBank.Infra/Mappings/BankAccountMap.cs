using ChallengeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeBank.Infra.Mappings
{
    public static class BankAccountMap
    {
        public static void Map(this EntityTypeBuilder<BankAccount> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id);
            entity.Property(x => x.BankBranch);
            entity.Property(x => x.AccountNumber);
            entity.Property(x => x.Balance);
            entity.Property(x => x.CreatedAt);
        }
    }
}
