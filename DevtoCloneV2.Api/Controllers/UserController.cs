using Microsoft.AspNetCore.Mvc;

namespace DevtoCloneV2.Api.Controllers
{
    [ApiController]
    [Route("/api/controller")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
