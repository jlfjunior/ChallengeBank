using ChallengeBank.Domain.Entities;
using System.Collections.Generic;

namespace ChallengeBank.Infra.Interfaces
{
    public interface IBankAccountRepository : IRepository<BankAccount>
    {
        IEnumerable<BankAccount> GetBankAccountsAvailableForRemunerate();
        void UpdateRange(ICollection<BankAccount> bankAccounts);
    }
}
