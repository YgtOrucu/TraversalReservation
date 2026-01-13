using DataAccessLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using TraversalReservation.CQRS.Result.DestinationResult;

namespace TraversalReservation.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandlers
    {
        private readonly TraversalContext _traversalContext;

        public GetAllDestinationQueryHandlers(TraversalContext traversalContext)
        {
            _traversalContext = traversalContext;
        }


        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _traversalContext.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                DestinationID = x.DestinationID,
                Capacity = x.Capacity,
                City = x.City,
                DayAndNight = x.DayAndNight,
                Price = x.Price
            }).AsNoTracking().ToList();

            return values;
        }

    }
}
