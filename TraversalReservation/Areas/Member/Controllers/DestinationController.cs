using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {

        public readonly IDestinationService _destinationService;

        public DestinationController()
        {
            _destinationService = new DestinationManager(new EFDestinationDal());
        }

        public IActionResult MembersDestination()
        {
            var values = _destinationService.TListingActiveRoutesForMembers();
            return View(values);
        }
    }
}
