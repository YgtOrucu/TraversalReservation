using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
