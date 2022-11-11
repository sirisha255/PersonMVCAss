using Microsoft.AspNetCore.Mvc;
using PersonMVCAss.Models;
using PersonMVCAss.Models.Repos;
using PersonMVCAss.Models.Service;
using PersonMVCAss.Models.VIewModels;

namespace PersonMVCAss.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;

        public PeopleController()
        {
            _peopleService = new PeopleService(new InMemoryPeopleRepo());
        }
        public IActionResult People() // if needed
        {
            return View(_peopleService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreatePersonViewModel());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Create(CreatePersonViewModel createPerson)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _peopleService.Create(createPerson);

                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("People & City", exception.Message);
                    return View(createPerson);

                }
                return RedirectToAction(nameof(Person));

            }
            return View(createPerson);
        }

        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person == null)
            {
                return RedirectToAction(nameof(Person));

            }
            return View(person);
        }
        public IActionResult LastPersonArrivel()
        {
            Person person = _peopleService.LastAdded();
            if (person != null)
            {
                return PartialView("_PeopleRow", person);
            }
            return NotFound();
        }

        public IActionResult LastPersonArrivelJSON()
        {

            Person person = _peopleService.LastAdded();
            if (person != null)
            {
                return Json(person);
            }
            return NotFound();
        }

        public IActionResult AjaxPersonList()
        {
            List<Person> person = _peopleService.GetAll();
            if (person != null)
            {
                return PartialView("_PersonList", person);
            }
            return BadRequest();

        }
    }
}
