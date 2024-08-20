using Microsoft.AspNetCore.Mvc;

namespace TaskSchedulerAPI.Presentation.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
