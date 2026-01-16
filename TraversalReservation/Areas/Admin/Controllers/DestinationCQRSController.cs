using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalReservation.CQRS.Commands.DestinationCommands;
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
        private readonly CreateDestinationCommandHandle _createDestinationCommandHandle;
        public DestinationCQRSController(GetAllDestinationQueryHandlers queryHandlers, GetDestinationByIDQueryHandlers getDestinationByIDQueryHandlers, CreateDestinationCommandHandle createDestinationCommandHandle)
        {
            _queryHandlers = queryHandlers;
            _getDestinationByIDQueryHandlers = getDestinationByIDQueryHandlers;
            _createDestinationCommandHandle = createDestinationCommandHandle;
        }

        public IActionResult Index()
        {
            var values = _queryHandlers.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult EditDestinationCQRS(int id)
        {
            var values = _getDestinationByIDQueryHandlers.Handle(new GetDestinationByIDQuery(id));
            return View(values);
        }
        [HttpGet]
        public IActionResult AddDestinationCQRS()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestinationCQRS(CreateDestinationCommands createDestination)
        {
            _createDestinationCommandHandle.Handle(createDestination);
            return RedirectToAction("Index");
        }
    }
}
