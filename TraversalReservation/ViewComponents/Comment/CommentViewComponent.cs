using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.Comment
{
    public class CommentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/Comment/Comment.cshtml");
        }
    }
}
