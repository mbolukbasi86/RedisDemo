using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisDemo.Interfaces;
using RedisDemo.Services;

namespace RedisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IRedisService redisService;

        public RedisController(IRedisService _redisService)
        {
            redisService = _redisService;
        }

        [HttpPost("set")]
        public async Task<IActionResult> SetValue(string key, string value)
        {
            await redisService.SetValueAsync(key, value);
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetValue(string key)
        {
            var value = await redisService.GetValueAsync(key);
            return Ok(value);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteValue(string key)
        {
            var result = await redisService.DeleteValueAsync(key);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
