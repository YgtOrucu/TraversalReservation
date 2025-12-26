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
        public PopularDestinationsViewComponent()
        {
            _destinationService = new DestinationManager(new EFDestinationDal());
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetAllList();
            return View("~/Views/Shared/Components/HomePage/PopularDestinations.cshtml", values);
        }
    }
}
