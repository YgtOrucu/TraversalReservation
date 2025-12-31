using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.AdminDashboard
{
    public class GuideViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/AdminDashboard/Guide.cshtml");
        }
    }
}
