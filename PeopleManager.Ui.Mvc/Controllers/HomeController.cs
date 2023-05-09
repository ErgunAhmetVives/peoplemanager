using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Core;
using PeopleManager.Ui.Mvc.Models;
using System.Diagnostics;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly PeopleManagerDatabase _database;

        public HomeController(PeopleManagerDatabase peopleManagerDatabase)
        {
            _database = peopleManagerDatabase;
        }

        public IActionResult Index()
        {
            var people = _database.People;
            return View(people);
        }

        [HttpGet("Home/Detail/{id:int}")]
        public IActionResult Detail([FromRoute]int id)
        {
            var list = _database.People;
            var person = list.FirstOrDefault(list=> list.Id == id);
            if (person == null)
            {
                return RedirectToAction("Index");
            } else
            {
                return View("PersonDetails", person);
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}