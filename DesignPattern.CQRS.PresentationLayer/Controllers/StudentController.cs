using DesignPattern.CQRS.PresentationLayer.CQRS.Commands.StudentCommands;
using DesignPattern.CQRS.PresentationLayer.CQRS.Queries.StudentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesignPattern.CQRS.PresentationLayer.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllStudentQuery());
            return View(values);
        }

        public async Task<IActionResult> GetStudent(int id)
        {
            var values=await _mediator.Send(new GetStudentByIDQuery(id));
            return View(values);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(CreateStudentCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
