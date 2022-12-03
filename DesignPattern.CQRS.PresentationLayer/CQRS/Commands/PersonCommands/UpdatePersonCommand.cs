namespace DesignPattern.CQRS.PresentationLayer.CQRS.Commands.PersonCommands
{
    public class UpdatePersonCommand
    {
     
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Departman { get; set; }

    }
}
