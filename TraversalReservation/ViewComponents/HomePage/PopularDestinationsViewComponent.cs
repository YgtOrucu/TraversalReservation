using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.HomePage
{
    public class PopularDestinationsViewComponent : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        public PopularDestinationsViewComponent(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetAllList();
            return View("~/Views/Shared/Components/HomePage/PopularDestinations.cshtml", values);
        }
    }
}
