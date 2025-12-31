
using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.Comment
{
    public class AddCommentViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;

        public AddCommentViewComponent()
        {
            _commentService = new CommentManager(new EFCommentDal(new TraversalContext()));
        }
        public IViewComponentResult Invoke(int id)
        {
            return View("~/Views/Shared/Components/Comment/AddComment.cshtml", id);
        }
    }
}
