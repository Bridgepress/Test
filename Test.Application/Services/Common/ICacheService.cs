namespace Test.Application.Services.Common
{
    public interface ICacheService
    {
        ValueTask SetAsync<T>(string key, T value, TimeSpan ttl);

        ValueTask SetAsync<T>(string key, T value);

        ValueTask SetAsync<T>(string key, T value, DateTime? expiryDate);

        ValueTask<T?> GetAsync<T>(string key);

        ValueTask<T?> GetAndRemoveAsync<T>(string key);

        ValueTask RemoveAsync(string key);
    }
}
