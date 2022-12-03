using DesignPattern.CQRS.PresentationLayer.CQRS.Commands.UniversityCommands;
using DesignPattern.CQRS.PresentationLayer.CQRS.Handlers.UniversityHandlers;
using DesignPattern.CQRS.PresentationLayer.CQRS.Queries.UniversityQueries;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.PresentationLayer.Controllers
{
    public class UniversityController : Controller
    {
        private readonly GetAllUniversityQueryHandler _getAllUniversityQueryHandler;
        private readonly GetUniversityByIDQueryHandler _getUniversityByIDQueryHandler;
        private readonly CreateUniversityHandler _createUniversityHandler;
        private readonly RemoveUniversityHandler _removeUniversityHandler;
        private readonly GetUniversityUpdateByIDQueryHandler _getUniversityUpdateByIDQueryHandler;
        private readonly UpdateUniversityHandler _updateUniversityHandler;

        public UniversityController(GetAllUniversityQueryHandler getAllUniversityQueryHandler, GetUniversityByIDQueryHandler getUniversityByIDQueryHandler, CreateUniversityHandler createUniversityHandler, RemoveUniversityHandler removeUniversityHandler, GetUniversityUpdateByIDQueryHandler getUniversityUpdateByIDQueryHandler, UpdateUniversityHandler updateUniversityHandler)
        {
            _getAllUniversityQueryHandler = getAllUniversityQueryHandler;
            _getUniversityByIDQueryHandler = getUniversityByIDQueryHandler;
            _createUniversityHandler = createUniversityHandler;
            _removeUniversityHandler = removeUniversityHandler;
            _getUniversityUpdateByIDQueryHandler = getUniversityUpdateByIDQueryHandler;
            _updateUniversityHandler = updateUniversityHandler;
        }

        public IActionResult Index()
        {
            var values = _getAllUniversityQueryHandler.Handle(new GetAllUniversityQuery());
            return View(values);
        }


        public IActionResult GetUniversity(int id)
        {
            var values = _getUniversityByIDQueryHandler.Handle(new GetUniversityByIDQuery(id));
            return View(values);
        }



        [HttpGet]
        public IActionResult AddUniversity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUniversity(CreateUniversityCommand command)
        {
            _createUniversityHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteUniversity(int id)
        {
            _removeUniversityHandler.Handle(new RemoveUniversityCommand(id));
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateUniversity(int id)
        {
            var values = _getUniversityUpdateByIDQueryHandler.Handle(new GetUniversityUpdateByIDQuery(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateUniversity(UpdateUniversityCommand command)
        {
            _updateUniversityHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
