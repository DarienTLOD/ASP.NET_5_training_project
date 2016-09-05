using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System.Linq;
using TrainingProject.Models;

namespace TrainingProject.Controllers
{
    public class HomeController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult IndexNew()
        {
            return View();
        }

        [Authorize]
        public IActionResult Task()
        {
            int selectedIndex = 1;
            SelectList states = new SelectList(db.States, "Id", "Name", selectedIndex);
            ViewBag.States = states;
            SelectList cities = new SelectList(db.Cities.Where(c => c.StateId == selectedIndex), "Id", "Name");
            ViewBag.Cities = cities;
            return View();
        }

        public ActionResult GetItems(int id)
        {
            return PartialView(db.Cities.Where(c => c.StateId == id).ToList());
        }
    }
}
