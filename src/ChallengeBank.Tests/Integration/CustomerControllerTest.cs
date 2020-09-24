using ChallengeBank.Api.ViewModels;
using ChallengeBank.Tests.Fakes;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ChallengeBank.Tests.Integration
{
    public class CustomerControllerTest : IClassFixture<StartupFake>
    {
        private const string _URL = "api/customers";
        private readonly StartupFake _startup;

        public CustomerControllerTest(StartupFake startup)
        {
            _startup = startup;
        }

        [Fact]
        public async Task ShouldCreate()
        {
            var model = new CustomerViewModel
            {
                FirstName = "Olivia",
                LastName = "Melo"
            };

            var response = await _startup.CreateClient().PostAsJsonAsync(_URL, model);

            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        }
    }
}
