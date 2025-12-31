using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.AdminDashboard
{
    public class TotalRevenue1ViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/AdminDashboard/TotalRevenue1.cshtml");
        }
    }
}
