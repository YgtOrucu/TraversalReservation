using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.HomePage
{
    public class TestimonialsViewComponent : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialsViewComponent()
        {
            _testimonialService = new TestimonialManager(new EFTestimonialDal(new TraversalContext()));
        }
        public IViewComponentResult Invoke()
        {
            var values = _testimonialService.TGetAllList();
            return View("~/Views/Shared/Components/HomePage/Testimonials.cshtml", values);
        }
    }
}
