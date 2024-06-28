using RedisDemo.Interfaces;
using StackExchange.Redis;

namespace RedisDemo.Services
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer connectionMultiplexer;
        public RedisService(IConnectionMultiplexer _connectionMultiplexer)
        {
            connectionMultiplexer = _connectionMultiplexer;
        }
        public async Task<string> GetValueAsync(string key)
        {
            var db = connectionMultiplexer.GetDatabase();
            return await db.StringGetAsync(key);
        }

        public async Task SetValueAsync(string key, string value)
        {
            var db = connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(key, value);
        }

        public async Task<bool> DeleteValueAsync(string key)
        {
            var db = connectionMultiplexer.GetDatabase();
            return await db.KeyDeleteAsync(key);
        }
    }
}
