namespace NewCalculator.Core.Interfaces
{
    public interface IHttpClientService
    {
        Task<string> GetAsync(string url);
    }
}
