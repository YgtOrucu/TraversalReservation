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
        private readonly SignInManager<AppUser> _signInManager;


        public LoginController(UserManager<AppUser> user,SignInManager<AppUser> signIn)
        {
            _usermanager = user;
            _signInManager = signIn;
        }

        #region SınUp

        [HttpGet]
        public IActionResult SıgnUp()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> SıgnUp(UserRegisterViewModal p)
        {
            if (!ModelState.IsValid)
                return View(p);

            var appUser = new AppUser
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.Username
            };

            var result = await _usermanager.CreateAsync(appUser, p.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("SıgnIn");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(p);
        }

        #endregion


        #region SıgnIn

        [HttpGet]
        public IActionResult SıgnIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SıgnIn(UserSıgnInViewModal p)
        {
            if (!ModelState.IsValid)
                return View(p);

            var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, true);

            if (result.Succeeded)
            {
                return RedirectToAction("HomePage", "Users");
            }
            else
            {
                return RedirectToAction("SıgnIn");
            }
        }
        #endregion
    }
}
