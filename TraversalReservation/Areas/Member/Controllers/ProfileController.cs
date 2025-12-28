using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.Areas.Member.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult MembersProfile()
        {

            return View();
        }
    }
}
