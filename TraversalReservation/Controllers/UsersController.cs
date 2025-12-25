using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace TraversalReservation.Controllers
{
    public class UsersController : Controller
    {
        #region HomePageOperations
        public IActionResult HomePage()
        {
            return View();
        }
        #endregion
    }
}
