using BusinenssLayer.Abstract;
using BusinenssLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraversalReservation.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController()
        {
            _commentService = new CommentManager(new EFCommentDal());
        }
        [HttpPost]
        public IActionResult AddComment(Comment c)
        {
            c.Date = DateTime.Now;
            c.Status = true;
            _commentService.TInsert(c);
            return RedirectToAction("DestinationDetails", "Destination", new { id = c.DestinationID });
        }
    }
}
