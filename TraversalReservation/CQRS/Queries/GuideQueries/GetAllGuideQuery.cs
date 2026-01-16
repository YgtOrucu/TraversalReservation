using MediatR;
using TraversalReservation.CQRS.Result.GuideResult;

namespace TraversalReservation.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
