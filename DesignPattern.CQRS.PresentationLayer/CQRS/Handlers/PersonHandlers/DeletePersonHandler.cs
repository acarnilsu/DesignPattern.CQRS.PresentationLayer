using DesignPattern.CQRS.PresentationLayer.CQRS.Commands.PersonCommands;
using DesignPattern.CQRS.PresentationLayer.DAL.Concrete;

namespace DesignPattern.CQRS.PresentationLayer.CQRS.Handlers.PersonHandlers
{
    public class DeletePersonHandler
    {
        private readonly Context _context;

        public DeletePersonHandler(Context context)
        {
            _context = context;
        }

        public void Handle(DeletePersonCommand deletePersonCommand)
        {
            var values = _context.Persons.Find(deletePersonCommand.Id);
            _context.Remove(values);
            _context.SaveChanges();
        }
    }
}
