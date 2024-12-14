using NewCalculator.Core.Interfaces;

// Not using Moq in this setup cause of:  Moq exfiltrates developer's emails from their development machine and sends them off to third-party remote servers.
// Manually creating mocks for testings purpose.
namespace Tests.Mocks.Weather
{
    public class EmptyResponseHttpClientService : IHttpClientService
    {
        public Task<string> GetAsync(string url)
        {
            return Task.FromResult(string.Empty);
        }
    }
}


