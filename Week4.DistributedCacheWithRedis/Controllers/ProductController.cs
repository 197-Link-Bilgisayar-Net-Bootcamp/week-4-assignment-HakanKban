using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Week4.DistributedCacheWithRedis.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //Redis Serveri ayakta olmalı. Aslında redisi kuramadım o yüzden buradaki kodlar çalışmayacak :)
        IDistributedCache _distributedCache;

        public ProductController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        [HttpGet]
        public IActionResult CacheSetString()
        {
            //_distributedCache.SetString("date", DateTime.Now.ToString(), new DistributedCacheEntryOptions
            //{
            //    AbsoluteExpiration = DateTime.Now.AddSeconds(1200),
            //    SlidingExpiration = TimeSpan.FromSeconds(60)
            //}) ;  
            _distributedCache.SetString("date", DateTime.Now.ToString()
            );
            return Ok();
        }
        [HttpGet]
        public IActionResult CacheGetString()
        {
            string value = _distributedCache.GetString("date");
            return Ok(value);
        }

    }
}
