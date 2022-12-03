namespace DesignPattern.CQRS.PresentationLayer.CQRS.Commands.PersonCommands
{
    public class DeletePersonCommand
    {
        public DeletePersonCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
