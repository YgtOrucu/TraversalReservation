using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.ViewComponents.Comment
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;

        public CommentViewComponent()
        {
            _commentService = new CommentManager(new EFCommentDal());
        }
        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.TGetCommentsbyDestinationID(id);
            return View("~/Views/Shared/Components/Comment/Comment.cshtml", values);
        }
    }
}
