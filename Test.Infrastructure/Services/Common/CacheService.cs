using Microsoft.Extensions.Caching.Memory;
using Test.Application.Services.Common;

namespace Test.Infrastructure.Services.Common
{
    internal class CacheService(IMemoryCache memoryCache) : ICacheService
    {
        public ValueTask SetAsync<T>(string key, T value, TimeSpan ttl)
        {
            memoryCache.Set(key, value, DateTimeOffset.Now.Add(ttl));
            return ValueTask.CompletedTask;
        }

        public ValueTask SetAsync<T>(string key, T value)
        {
            memoryCache.Set(key, value);
            return ValueTask.CompletedTask;
        }

        public ValueTask SetAsync<T>(string key, T value, DateTime? expiryDate)
        {
            if (expiryDate.HasValue)
            {
                memoryCache.Set(key, value, new DateTimeOffset(expiryDate.Value));
            }
            else
            {
                memoryCache.Set(key, value);
            }

            return ValueTask.CompletedTask;
        }

        public ValueTask<T?> GetAsync<T>(string key)
        {
            return ValueTask.FromResult(memoryCache.Get<T>(key));
        }

        public async ValueTask<T?> GetAndRemoveAsync<T>(string key)
        {
            var value = await this.GetAsync<T>(key);
            if (value != null) memoryCache.Remove(key);
            return value;
        }

        public ValueTask RemoveAsync(string key)
        {
            memoryCache.Remove(key);
            return ValueTask.CompletedTask;
        }
    }
}
