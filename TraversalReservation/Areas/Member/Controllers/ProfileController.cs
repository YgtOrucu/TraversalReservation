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
                Mail = values.Email,
                ImgUrl = values.ImgUrl,
                PhoneNumber = values.PhoneNumber
            };
            return View(userEdit);
        }



        [HttpGet]
        public async Task<IActionResult> MembersEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            UserEditViewModal userEdit = new UserEditViewModal()
            {
                Name = values.Name,
                Surname = values.Surname,
                Username = values.UserName,
                Mail = values.Email,
                PhoneNumber = values.PhoneNumber
            };
            return View(userEdit);
        }

        [HttpPost]
        public async Task<IActionResult> MembersProfile(UserEditViewModal user)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extencion = Path.GetExtension(user.Image.FileName);
                var ımage = Guid.NewGuid() + extencion;
                var savelocation = resource + "/wwwroot/UserImages/" + ımage;
                var stream = new FileStream(savelocation, FileMode.Create);
                await user.Image.CopyToAsync(stream);
                user.ImgUrl = ımage;
                values.ImgUrl = "/userimages/" + user.ImgUrl;
            }

            values.Name = user.Name;
            values.Surname = user.Surname;
            values.UserName = user.Username;
            values.PhoneNumber = user.PhoneNumber;
                if (user.Password != null)
                    values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, user.Password);

            var result = await _userManager.UpdateAsync(values);

            if (result.Succeeded)
            {
                return RedirectToAction("SıgnIn", "Login");
            }
            return View();
        }
    }
}
