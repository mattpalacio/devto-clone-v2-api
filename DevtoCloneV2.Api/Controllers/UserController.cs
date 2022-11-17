using Microsoft.AspNetCore.Mvc;

namespace DevtoCloneV2.Api.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
