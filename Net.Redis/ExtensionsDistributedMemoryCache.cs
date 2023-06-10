using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

public static class ExtensionsDistributedMemoryCache
{

    public static void Set<T>(this IDistributedCache cache, string key, T value) where T : class
    {
        string json = JsonSerializer.Serialize(value);
        cache.SetString(key, json, new DistributedCacheEntryOptions()
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10),
        });
    }


    public static T? Get<T>(this IDistributedCache cache, string key) where T : class
    {
        string? json = cache.GetString(key);

        return json != null 
            ? JsonSerializer.Deserialize<T>(json) : default(T);
    }

}