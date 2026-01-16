using DataAccessLayer.Concreate;
using TraversalReservation.CQRS.Queries.DestinationQueries;
using TraversalReservation.CQRS.Result.DestinationResult;

namespace TraversalReservation.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandlers
    {
        private readonly TraversalContext _traversalContext;

        public GetDestinationByIDQueryHandlers(TraversalContext traversalContext)
        {
            _traversalContext = traversalContext;
        }

        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery byIDQuery)
        {
            var values = _traversalContext.Destinations.Find(byIDQuery.ıd);

            return new GetDestinationByIDQueryResult
            {
                DestinationID = values.DestinationID,
                City = values.City,
                DayAndNight = values.DayAndNight,
                Price = values.Price
            };
        }
    }
}
