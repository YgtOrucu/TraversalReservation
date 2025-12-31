using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.HomePage
{
    public class StatsViewComponent : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly IGuideService _guideService;

        public StatsViewComponent(IDestinationService destinationService)
        {
            _destinationService = destinationService;
            _guideService = new GuideManager(new EFGuideDal(new TraversalContext()));
        }

        public IViewComponentResult Invoke()
        {

            ViewBag.RoutesCount = _destinationService.TGetDestinationCount();
            ViewBag.TourGuide = _guideService.TGetGuideCount();
            ViewBag.Customers = "280";
            ViewBag.Awards = "15";


            return View("~/Views/Shared/Components/HomePage/Stats.cshtml");
        }
    }
}
