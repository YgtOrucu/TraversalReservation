using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalReservation.Models;

namespace TraversalReservation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;

        public LoginController(UserManager<AppUser> user)
        {
            _usermanager = user;
        }
        [HttpGet]
        public IActionResult SıngUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SıngUp(UserRegisterViewModal p)
        {
            AppUser appUser = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.Username
            };
            if(p.Password == p.ConfirmPassword)
            {
                var result = await _usermanager.CreateAsync(appUser, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("SıngIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult SıngIn()
        {
            return View();
        }
    }
}
