using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Week4.AuthorizationWithJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public string Index()
        {
            return "Yetkilendirme başarılı...";
        }
    }
}
