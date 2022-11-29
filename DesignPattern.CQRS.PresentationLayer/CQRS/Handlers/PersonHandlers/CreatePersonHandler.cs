using DesignPattern.CQRS.PresentationLayer.CQRS.Commands.PersonCommands;
using DesignPattern.CQRS.PresentationLayer.DAL.Concrete;
using DesignPattern.CQRS.PresentationLayer.DAL.Entity;
using System;

namespace DesignPattern.CQRS.PresentationLayer.CQRS.Handlers.PersonHandlers
{
    public class CreatePersonHandler
    {
        private readonly Context _context;

        public CreatePersonHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreatePersonCommand command)
        {
            _context.Persons.Add(new Person
            {
                City = command.City,
                Name = command.Name,
                Surname = command.Surname,
                Salary = command.Salary,
                Status = true,
                StartWork = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            });
            _context.SaveChanges();
        }
    }
}
