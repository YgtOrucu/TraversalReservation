using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalReservation.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class ReservationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager,IDestinationService destinationService)
        {
            _destinationService = destinationService;
            _reservationService = new ReservationManager(new EFReservationDal(new TraversalContext()));
            _userManager = userManager;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {
            var member = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.TGetActiveReservation(member.Id);
            return View(values);
        }

        public async Task<IActionResult> MyOldReservation()
        {
            var member = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.TGetOldReservation(member.Id);
            return View(values);
        }

        public IActionResult CanselReservation(int id)
        {
            var updatedreservation = _reservationService.TGetByID(id);
            updatedreservation.Status = "Kullanıcı İptal Etti";
            _reservationService.TUpdate(updatedreservation);
            return RedirectToAction("MyCurrentReservation", "Reservation", new { area = "Member" });
        }

        [HttpGet]
        public async Task<IActionResult> NewReservation()
        {
            #region GetDestination
            var values = _destinationService.TGetAllList().Select(x => new SelectListItem
            {
                Value = x.DestinationID.ToString(),
                Text = x.City
            }).ToList();

            ViewBag.Destination = values;
            #endregion

            #region GetMembersId
            var getmember = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.MembersId = getmember.Id;

            #endregion
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation r)
        {
            _reservationService.TInsert(r);
            return RedirectToAction("NewReservation", "Reservation", new { area = "Member" });

        }
    }
}
