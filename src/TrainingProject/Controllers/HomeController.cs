using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace TrainingProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [Authorize]
        public IActionResult Task()
        {
            return View();
        }
    }
}
