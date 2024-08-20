using Microsoft.AspNetCore.Mvc;

namespace TaskSchedulerAPI.Presentation.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
