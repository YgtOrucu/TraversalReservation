using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.HomePage
{
    public class SubAboutViewComponent : ViewComponent
    {
        private readonly ISubAboutService _subAboutService;

        public SubAboutViewComponent()
        {
            _subAboutService = new SubAboutManager(new EFSubAboutDal());
        }
        public IViewComponentResult Invoke()
        {
            var values = _subAboutService.TGetAllList();
            return View("~/Views/Shared/Components/HomePage/SubAbout.cshtml", values);
        }
    }
}
