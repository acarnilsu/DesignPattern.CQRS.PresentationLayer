using DesignPattern.CQRS.PresentationLayer.CQRS.Commands.PersonCommands;
using DesignPattern.CQRS.PresentationLayer.DAL.Concrete;
using System.Linq;

namespace DesignPattern.CQRS.PresentationLayer.CQRS.Handlers.PersonHandlers
{
    public class UpdatePersonHandler
    {
        private readonly Context _context;

        public UpdatePersonHandler(Context context)
        {
            _context = context;
        }

        public UpdatePersonCommand FindPerson(int id)     //get işlemi
        {
            var person = _context.Persons.
                  Where(x => x.PersonID == id)
                  .Select(x => new { x.Name, x.Surname, x.Mail, x.Phone, x.Department, x.City }
                  ).First();
            UpdatePersonCommand command = new UpdatePersonCommand();
            command.PersonID = id;
            command.City = person.City;
            command.Name = person.Name;
            command.Surname = person.Surname;
            command.Mail = person.Mail;
            command.Departman = person.Department;
            command.Phone = person.Phone;
            
            return command;
        }





        public void Handle(UpdatePersonCommand command)    //post işlemi
        {
            var value = _context.Persons.Find(command.PersonID);
            value.City = command.City;
            value.Name = command.Name;
            value.Surname = command.Surname;
            value.Mail = command.Mail;
            value.Department = command.Departman;
            value.Phone = command.Phone;
            _context.SaveChanges();
        }

    }
}
