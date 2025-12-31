using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.Controllers
{
    public class DestinationController : Controller
    {
        public readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetAllList();
            return View(values);
        }
        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            var values = _destinationService.TGetByID(id);
            return View("DestinationDetails", values);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination d)
        {
            return View();
        }
    }
}
