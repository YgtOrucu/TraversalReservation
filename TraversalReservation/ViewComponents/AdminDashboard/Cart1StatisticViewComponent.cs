using BusinenssLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalReservation.Areas.Admin.Models;

namespace TraversalReservation.ViewComponents.AdminDashboard
{
    public class Cart1StatisticViewComponent : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;

        public Cart1StatisticViewComponent(IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            Car1Statictic car1Statictic = new Car1Statictic
            {
                AppUserCount = _userManager.Users.Count(),
                DestinationCount = _destinationService.TGetAllList().Count()
            };

            return View("~/Views/Shared/Components/AdminDashboard/Cart1Statistic.cshtml", car1Statictic);
        }
    }
}
