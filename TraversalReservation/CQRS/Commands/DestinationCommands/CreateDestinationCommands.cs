using EntityLayer.Concreate;

namespace TraversalReservation.CQRS.Commands.DestinationCommands
{
    public class CreateDestinationCommands
    {
        public string City { get; set; }
        public string DayAndNight { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
    }
}
