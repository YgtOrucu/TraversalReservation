using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using TraversalReservation.Models;

namespace TraversalReservation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LoginController> _logger;

        public LoginController(UserManager<AppUser> user, SignInManager<AppUser> signIn, ILogger<LoginController> logger)
        {
            _usermanager = user;
            _signInManager = signIn;
            _logger = logger;
        }

        #region SınUp

        [HttpGet]
        public IActionResult SıgnUp()
        {
            _logger.LogInformation($"SıgnUp Sayfası Çağırıldı");
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> SıgnUp(UserRegisterViewModal p)
        {
            var datetime = DateTime.Now.ToShortDateString();

            if (!ModelState.IsValid)
                return View(p);

            var appUser = new AppUser
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.Username,
                PhoneNumber = p.Phone
            };

            var result = await _usermanager.CreateAsync(appUser, p.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation($"{datetime} Kullanıcı Girişi Başlarılı");
                return RedirectToAction("SıgnIn");
            }

            foreach (var item in result.Errors)
            {
                _logger.LogError($"başarısız");
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
                return RedirectToAction("MembersProfile", "Profile", new { area = "Member" });
            }
            else
            {
                return RedirectToAction("SıgnIn");
            }
        }
        #endregion
    }
}
