using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalReservation.Areas.Member.Models;

namespace TraversalReservation.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> MembersProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            UserEditViewModal userEdit = new UserEditViewModal()
            {
                Name = values.Name,
                Surname = values.Surname,
                Username = values.UserName,
                Mail = values.Email
            };
            return View(userEdit);
        }
    }
}
