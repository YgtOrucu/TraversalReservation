using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalReservation.CQRS.Handlers.DestinationHandlers;
using TraversalReservation.CQRS.Queries.DestinationQueries;

namespace TraversalReservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandlers _queryHandlers;
        private readonly GetDestinationByIDQueryHandlers _getDestinationByIDQueryHandlers;
        public DestinationCQRSController(GetAllDestinationQueryHandlers queryHandlers, GetDestinationByIDQueryHandlers getDestinationByIDQueryHandlers)
        {
            _queryHandlers = queryHandlers;
            _getDestinationByIDQueryHandlers = getDestinationByIDQueryHandlers;
        }

        public IActionResult Index()
        {
            var values = _queryHandlers.Handle();
            return View(values);
        }

        public IActionResult GetDestination(int id)
        {
            var values = _getDestinationByIDQueryHandlers.Handle(new GetDestinationByIDQuery(id));
            return View(values);
        }
    }
}
