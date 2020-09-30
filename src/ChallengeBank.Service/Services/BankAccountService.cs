using ChallengeBank.Domain.Entities;
using ChallengeBank.Domain.Enums;
using ChallengeBank.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ChallengeBank.Service.Services
{
    public class BankAccountService
    {
        private const decimal _SELIC = 4.49M;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IDailyBalanceRepository _dailyBalanceRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository, IDailyBalanceRepository dailyBalanceRepository)
        {
            _bankAccountRepository = bankAccountRepository;
            _dailyBalanceRepository = dailyBalanceRepository;
        }

        public BankAccount Create(BankAccount bankAccount)
        {
            _bankAccountRepository.Add(bankAccount);

            return bankAccount;
        }

        public IEnumerable<BankAccount> GetBankAccounts()
        {
            return _bankAccountRepository.GetBankAccounts();
        }

        public void RemunerateAccounts()
        {
            var dailyBalancesToday = _dailyBalanceRepository.GetDailyBalances(DateTime.Now);
            var bankAccounts = _bankAccountRepository.GetBankAccountsAvailableForRemunerate();
            var bankAccountForUpdate = new List<BankAccount>();
            var dailyBalances = new List<DailyBalance>();
            var transactions = new List<Transaction>();
            var bankAccountId = dailyBalancesToday.Select(x => x.BankAccountId).ToList();
            
            foreach (var item in bankAccounts.Where(x => !bankAccountId.Contains(x.Id)).ToList())
            {
                var dailyBalance = new DailyBalance
                {
                    BankAccountId = item.Id,
                    Balance = item.Balance,
                    Date = DateTime.Now,
                    RemuneratedAmount = GetRemunerateAmount(item.Balance)
                };

                var transaction = new Transaction
                {
                    BankAccountId = item.Id,
                    Amount = dailyBalance.RemuneratedAmount,
                    Type = TransactionType.Interest
                };

                if (dailyBalance.RemuneratedAmount > 0)
                {
                    dailyBalances.Add(dailyBalance);
                    transactions.Add(transaction);

                    item.Balance += dailyBalance.RemuneratedAmount;

                    bankAccountForUpdate.Add(item);
                }
            }
            
            _dailyBalanceRepository.AddRange(dailyBalances);
            _bankAccountRepository.UpdateRange(bankAccountForUpdate);
        }

        private decimal GetRemunerateAmount(decimal amount)
        {
            var percentSelicByDay = _SELIC / DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) / 100;
            var isSaturday = DateTime.Now.DayOfWeek != DayOfWeek.Saturday;
            var isSunday = DateTime.Now.DayOfWeek != DayOfWeek.Sunday;
            
            return (isSaturday || isSunday)  ? 0 : amount * percentSelicByDay;
        }
    }
}
