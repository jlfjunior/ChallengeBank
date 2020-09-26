using ChallengeBank.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeBank.Api.Results
{
    public class BankAccountStatementJson : IActionResult
    {
        public long BankAccountId { get; set; }
        public ICollection<StatementJson> Statements { get; set; }


        public BankAccountStatementJson() { }

        public BankAccountStatementJson(ICollection<Transaction> transactions)
        {
            BankAccountId = transactions.First().BankAccountId;
            Statements = transactions.Select(x => new StatementJson(x)).ToList();
        }


        public async Task ExecuteResultAsync(ActionContext context)
        {
            await new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
