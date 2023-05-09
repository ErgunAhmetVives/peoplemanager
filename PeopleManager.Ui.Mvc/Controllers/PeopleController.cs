using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Core;
using PeopleManager.Ui.Mvc.Models;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleManagerDBContext _database;

        public PeopleController(PeopleManagerDBContext peopleManagerDatabase)
        {
            _database = peopleManagerDatabase;
        }
        public IActionResult Index()
        {
            var people = _database.People.ToList();
            return View(people);
        }

        [HttpGet("/Person/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/Person/create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            _database.People.Add(person);
            _database.SaveChanges();
            return RedirectToAction("index");
        }
     


        
    }
}
