using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Core;
using PeopleManager.Ui.Mvc.Models;
using System.Diagnostics;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly PeopleManagerDBContext _database;

        public HomeController(PeopleManagerDBContext peopleManagerDatabase)
        {
            _database = peopleManagerDatabase;
        }

        public IActionResult Index()
        {
            var people = _database.People.ToList();
            return View(people);
        }

        [HttpGet("Home/Detail/{id:int}")]
        public IActionResult Detail([FromRoute]int id)
        {
            var list = _database.People.ToList();
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