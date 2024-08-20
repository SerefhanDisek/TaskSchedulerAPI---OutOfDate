using Microsoft.AspNetCore.Mvc;

namespace TaskSchedulerAPI.Presentation.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
