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

        [HttpPost]
        public async Task<IActionResult> MembersProfile(UserEditViewModal user)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string password = values.PasswordHash;
            if (user.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(user.Image.FileName);
                var imageName = Guid.NewGuid() + extension;

                var uploadPath = Path.Combine(resource, "wwwroot", "userimages");
                var saveLocation = Path.Combine(uploadPath, imageName);

                // 🔥 ESKİ RESMİ SİL
                if (!string.IsNullOrEmpty(values.ImgUrl))
                {
                    var oldImagePath = Path.Combine(
                        resource,
                        "wwwroot",
                        values.ImgUrl.TrimStart('/')
                    );

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using var stream = new FileStream(saveLocation, FileMode.Create);
                await user.Image.CopyToAsync(stream);

                values.ImgUrl = "/userimages/" + imageName;
            }


            values.Name = user.Name;
            values.Surname = user.Surname;
            values.UserName = user.Username;
            values.PhoneNumber = user.PhoneNumber;
            if (user.Password != null)
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, user.Password);
            string changepassword = values.PasswordHash;

            var result = await _userManager.UpdateAsync(values);

            if (result.Succeeded)
            {
                if (password != changepassword)
                {
                    return RedirectToAction("SıgnIn", "Login");
                }
                else
                {
                    return RedirectToAction("MembersProfile", "Profile", new { area = "member" });
                }
            }
            return View();
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

    }
}
