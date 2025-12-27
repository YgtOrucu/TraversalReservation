using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.Comment
{
    public class AddCommentViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/Comment/AddComment.cshtml");
        }
    }
}
