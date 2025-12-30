using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminController : Controller
    {
        private readonly IDestinationService _destinationService;

        public AdminController()
        {
            _destinationService = new DestinationManager(new EFDestinationDal());
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

    }
}
