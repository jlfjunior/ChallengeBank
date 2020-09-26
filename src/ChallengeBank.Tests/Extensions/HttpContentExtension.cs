using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChallengeBank.Tests.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var stringContent = await content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(stringContent);
        }
    }
}
