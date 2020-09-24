using ChallengeBank.Tests.Fakes;
using System.Threading.Tasks;
using Xunit;

namespace ChallengeBank.Tests.Integration
{
    public class BankAccountControllerTest : IClassFixture<StartupFake>
    {
        private const string _URL = "api/bank-accounts";
        private readonly StartupFake _startup;

        public BankAccountControllerTest(StartupFake startup)
        {
            _startup = startup;
        }

        [Fact]
        public async Task ShouldCreate()
        {

        }
    }
}
