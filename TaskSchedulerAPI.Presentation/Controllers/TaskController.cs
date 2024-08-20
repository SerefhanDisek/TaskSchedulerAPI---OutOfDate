using Microsoft.AspNetCore.Mvc;

namespace TaskSchedulerAPI.Presentation.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
