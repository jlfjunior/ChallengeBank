using ChallengeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeBank.Infra.Mappings
{
    public static class TransactionMap
    {
        public static void Map(this EntityTypeBuilder<Transaction> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id);
            entity.Property(x => x.BankAccountId);
            entity.Property(x => x.Amount);
        }
    }
}
