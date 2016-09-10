using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System.Linq;
using TrainingProject.Models;

namespace TrainingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
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
        [HttpGet]
        public IActionResult Task()
        {
            var countries = new SelectList(_db.Countries, "Id", "Name", 1);
            ViewBag.Countries = countries;
            var states = new SelectList(_db.States.Where(c => c.CountryId == 1), "Id", "Name");
            ViewBag.States = states;
            var cities = new SelectList(_db.Cities.Where(c => c.StateId == 1), "Id", "Name");
            ViewBag.Cities = cities;
            return View();
        }

        [HttpPost]
        public IActionResult Task(CalculateModel calc)
        {           
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(calc.Calculate()));
        }

        public ActionResult GetStates(int id)
        {
            return PartialView(_db.States.Where(c => c.CountryId == id).ToList());
        }

        public ActionResult GetCities(int id)
        {
            return PartialView(_db.Cities.Where(c => c.StateId == id).ToList());
        }
    }
}
