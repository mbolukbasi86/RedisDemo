using Microsoft.AspNetCore.DataProtection.KeyManagement;
using StackExchange.Redis;

namespace RedisDemo.Interfaces
{
    public interface IRedisService
    {
        Task SetValueAsync(string key, string value);
        Task<string> GetValueAsync(string key);
        Task<bool> DeleteValueAsync(string key);
    }
}
