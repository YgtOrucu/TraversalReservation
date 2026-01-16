using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using TraversalReservation.CQRS.Commands.DestinationCommands;

namespace TraversalReservation.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandle
    {
        private readonly TraversalContext _traversalContext;

        public CreateDestinationCommandHandle(TraversalContext traversalContext)
        {
            _traversalContext = traversalContext;
        }


        public void Handle(CreateDestinationCommands destinationCommands)
        {
            _traversalContext.Destinations.Add(new Destination
            {
                City = destinationCommands.City,
                Price = destinationCommands.Price,
                DayAndNight = destinationCommands.DayAndNight,
                Capacity = destinationCommands.Capacity,
                Status = true
            });

            _traversalContext.SaveChanges();

        }
    }
}
