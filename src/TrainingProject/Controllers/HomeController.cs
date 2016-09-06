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
            var countries = new SelectList(db.Countries, "Id", "Name", 1);
            ViewBag.Countries = countries;
            var states = new SelectList(db.States.Where(c => c.CountryId == 1), "Id", "Name");
            ViewBag.States = states;
            var cities = new SelectList(db.Cities.Where(c => c.StateId == 1), "Id", "Name");
            ViewBag.Cities = cities;
            return View();
        }

        public ActionResult GetStates(int id)
        {
            return PartialView(db.States.Where(c => c.CountryId == id).ToList());
        }
        public ActionResult GetCities(int id)
        {
            return PartialView(db.Cities.Where(c => c.StateId == id).ToList());
        }
    }
}
