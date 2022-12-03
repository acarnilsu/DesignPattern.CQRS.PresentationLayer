using DesignPattern.CQRS.PresentationLayer.CQRS.Commands.PersonCommands;
using DesignPattern.CQRS.PresentationLayer.CQRS.Handlers.PersonHandlers;
using DesignPattern.CQRS.PresentationLayer.CQRS.Queries.PersonQueries;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.PresentationLayer.Controllers
{
    public class PersonController : Controller
    {
        private readonly GetPersonHumanResourceQueryHandler _getPersonHumanResourceQueryHandler;
        private readonly GetPersonByIDQueryHandler _getPersonByIDQueryHandler;
        private readonly CreatePersonHandler _createPersonHandler;
        private readonly DeletePersonHandler _deletePersonHandler;
        private readonly UpdatePersonHandler _updatePersonHandler;

        public PersonController(GetPersonHumanResourceQueryHandler getPersonHumanResourceQueryHandler, GetPersonByIDQueryHandler getPersonByIDQueryHandler, CreatePersonHandler createPersonHandler, DeletePersonHandler deletePersonHandler, UpdatePersonHandler updatePersonHandler)
        {
            _getPersonHumanResourceQueryHandler = getPersonHumanResourceQueryHandler;
            _getPersonByIDQueryHandler = getPersonByIDQueryHandler;
            _createPersonHandler = createPersonHandler;
            _deletePersonHandler = deletePersonHandler;
            _updatePersonHandler = updatePersonHandler;
        }

        public IActionResult Index()
        {
            var values = _getPersonHumanResourceQueryHandler.Handle(new GetPersonHumanResourceQuery());
            return View(values);
        }

        public IActionResult GetPerson(int id)
        {
            var values = _getPersonByIDQueryHandler.Handle(new GetPersonByIDQuery(id));
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(CreatePersonCommand command)
        {
            _createPersonHandler.Handle(command);
            return RedirectToAction("Index");
        }


        public IActionResult DeletePerson(int id)
        {
            _deletePersonHandler.Handle(new DeletePersonCommand(id));
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdatePerson(int id)
        {
            var values = _updatePersonHandler.FindPerson(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdatePerson(UpdatePersonCommand command)
        {
            _updatePersonHandler.Handle(command);
            return RedirectToAction("Index");
        }

    }
}
