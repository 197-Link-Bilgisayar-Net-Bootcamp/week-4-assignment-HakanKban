using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Week4.MemoryCache.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IMemoryCache _memoryCache;
        //Dependecy injection ile ImemoryCache üzerinden nesne talebi
        public EmployeeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        // set metodu ile datayı cacheleyeceğiz. Key-value şeklinde
        [HttpGet]
        public IActionResult SetCache()
        {
            _memoryCache.Set("employeeName", "Hakan");
            return Ok();
        }

        //get ile cachelenen veriyi okuyacağız
        [HttpGet]
        public IActionResult GetCache()
        {
            var value= _memoryCache.Get<string>("employeeName");
            return Ok(value);
        }
        //remove ile cachelenen veriyi sileceğiz.
        [HttpGet]
        public IActionResult RemoveCache()
        {
            _memoryCache.Remove("employeeName");
            return Ok();
        }
        // TryGetValue ile veriyi sorgular var ise true döner. Ve out ile cacheden data döner
        [HttpGet]
        public IActionResult TryGetValue()
        {
            if (_memoryCache.TryGetValue<string>("employeeName", out string data))
            {
                return Ok(data);
            }
            return Ok();
        }
        // Metodlar çeşitlendirilebilir. Cache priority konusuna bak. Memory nin dolmasında silemecek verilerin
        // öncelik olarak silinmesi. Ve zamanlama metodları
    }
}
