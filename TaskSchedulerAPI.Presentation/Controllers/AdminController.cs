using Microsoft.AspNetCore.Mvc;

namespace TaskSchedulerAPI.Presentation.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
