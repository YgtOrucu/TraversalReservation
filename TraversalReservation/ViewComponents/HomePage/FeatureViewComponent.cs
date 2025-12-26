using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.HomePage
{
    public class FeatureViewComponent : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public FeatureViewComponent()
        {
            _featureService = new FeatureManager(new EFFeatureDal());
        }
        public IViewComponentResult Invoke()
        {
            var values = _featureService.TGetAllList();
            return View("~/Views/Shared/Components/HomePage/Feature.cshtml", values);
        }
    }
}
