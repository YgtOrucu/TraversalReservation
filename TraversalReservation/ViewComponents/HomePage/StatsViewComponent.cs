using DataAccessLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.HomePage
{
    public class StatsViewComponent : ViewComponent
    {
        TraversalContext context = new TraversalContext();
        public IViewComponentResult Invoke()
        {

            ViewBag.RoutesCount = context.Destinations.Count();
            ViewBag.TourGuide = context.Guides.Count();
            ViewBag.Customers = "280";
            ViewBag.Awards = "15";


            return View("~/Views/Shared/Components/HomePage/Stats.cshtml");
        }
    }
}
