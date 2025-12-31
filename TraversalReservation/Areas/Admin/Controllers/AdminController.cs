using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly ICommentService _commentService;
        private readonly IReservationService _reservationService;
        private readonly IGuideService _guideService;
        private readonly UserManager<AppUser> _userManager;

        public AdminController
            (IDestinationService destinationService,
            ICommentService commentService,
            IReservationService reservationService,
            IGuideService guideService,
            UserManager<AppUser> userManager)

        {
            _destinationService = destinationService;
            _commentService = commentService;
            _userManager = userManager;
            _reservationService = reservationService;
            _guideService = guideService;
        }

        #region DestinationOpereations

        #region List
        public IActionResult Destination()
        {
            var values = _destinationService.TGetAllList();
            return View(values);
        }
        #endregion

        #region Add
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination d)
        {
            _destinationService.TInsert(d);
            return RedirectToAction("Destination");
        }
        #endregion

        #region EditAndUpdate
        [HttpGet]
        public IActionResult EditDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            return View("EditDestination", values);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination d)
        {
            _destinationService.TUpdate(d);
            return RedirectToAction("Destination");
        }
        #endregion

        #endregion

        #region DashboardOperation

        public IActionResult Dashboard()
        {
            return View();
        }

        #endregion

        #region CommentsOperation

        #region List
        public IActionResult Comments()
        {
            var values = _commentService.TGetCommentsForAdminPage();
            return View(values);
        }
        #endregion

        #region EditAndUpdate
        public IActionResult EditComments(int id)
        {
            var values = _commentService.TGetByID(id);
            return View("EditComments", values);
        }
        [HttpPost]
        public IActionResult UpdateComments(Comment c)
        {
            _commentService.TUpdate(c);
            return RedirectToAction("Comments");
        }
        #endregion



        #endregion

        #region MembersOperation

        #region List

        public IActionResult Members()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        public IActionResult OldReservation(int id)
        {
            var values = _reservationService.TGetOldReservation(id);
            return View(values);
        }
        #endregion

        #endregion

        #region Guide 

        #region List

        public IActionResult Guide()
        {
            var values = _guideService.TGetAllList();
            return View(values);
        }
        #endregion

        #region Add

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(Guide g)
        {
            _guideService.TInsert(g);
            return RedirectToAction("Guide");
        }
        #endregion

        #region EditAndUpdate

        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View("EditGuide", values);
        }

        [HttpPost]
        public IActionResult UpdateGuide(Guide g)
        {
            _guideService.TUpdate(g);
            return RedirectToAction("Guide");
        }

        #endregion

        #endregion

    }
}
