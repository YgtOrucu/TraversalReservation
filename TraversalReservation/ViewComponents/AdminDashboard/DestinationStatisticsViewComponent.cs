using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.AdminDashboard
{
    public class DestinationStatisticsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/AdminDashboard/DestinationStatistics.cshtml");
        }
    }
}
