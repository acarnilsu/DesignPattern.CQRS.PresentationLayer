using DesignPattern.CQRS.PresentationLayer.CQRS.Commands.UniversityCommands;
using DesignPattern.CQRS.PresentationLayer.DAL.Concrete;
using DesignPattern.CQRS.PresentationLayer.DAL.Entity;

namespace DesignPattern.CQRS.PresentationLayer.CQRS.Handlers.UniversityHandlers
{
    public class CreateUniversityHandler
    {
        private readonly Context _context;

        public CreateUniversityHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateUniversityCommand command)
        {
            _context.Universities.Add(new University
            {
                Name = command.Name,
                Population = command.Population
            });
            _context.SaveChanges();
        }
    }
}
