using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.AdminDashboard
{
    public class TotalRevenue2ViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/AdminDashboard/TotalRevenue2.cshtml");
        }
    }
}
