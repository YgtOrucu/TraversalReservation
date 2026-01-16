using DataAccessLayer.Concreate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TraversalReservation.CQRS.Queries.GuideQueries;
using TraversalReservation.CQRS.Result.GuideResult;

namespace TraversalReservation.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandlers : IRequestHandler<GetAllGuideQuery, List<GetAllGuideQueryResult>>
    {
        private readonly TraversalContext _traversalContext;
        public GetAllGuideQueryHandlers(TraversalContext traversalContext)
        {
            _traversalContext = traversalContext;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _traversalContext.Guides.Select(x => new GetAllGuideQueryResult
            {
                GuideID = x.GuideID,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image
            }).AsNoTracking().ToListAsync();
        }
    }
}
