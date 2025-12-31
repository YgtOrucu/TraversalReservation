using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.AdminDashboard
{
    public class DestinationStatistics2ViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/AdminDashboard/DestinationStatistics2.cshtml");
        }
    }
}
