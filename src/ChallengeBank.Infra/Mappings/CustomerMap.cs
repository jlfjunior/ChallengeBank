using ChallengeBank.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeBank.Infra.Mappings
{
    public static class CustomerMap
    {
        public static void Map(this EntityTypeBuilder<Customer> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id);
            entity.Property(x => x.LastName);
            entity.Property(x => x.FirstName);
        }
    }
}
