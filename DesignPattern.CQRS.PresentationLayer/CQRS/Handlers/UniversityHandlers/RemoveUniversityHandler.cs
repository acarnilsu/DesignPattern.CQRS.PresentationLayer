using DesignPattern.CQRS.PresentationLayer.CQRS.Commands.UniversityCommands;
using DesignPattern.CQRS.PresentationLayer.DAL.Concrete;

namespace DesignPattern.CQRS.PresentationLayer.CQRS.Handlers.UniversityHandlers
{
    public class RemoveUniversityHandler
    {
        private readonly Context _context;

        public RemoveUniversityHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveUniversityCommand command)
        {
            var values = _context.Universities.Find(command.Id);
            _context.Universities.Remove(values);
            _context.SaveChanges();
        }
    }
}
