using BusinenssLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinenssLayer.Concreate
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentService _commentService;
        public CommentManager(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public List<Comment> TGetAllList()
        {
            return _commentService.TGetAllList();
        }

        public Comment TGetByID(int id)
        {
            return _commentService.TGetByID(id);
        }

        public List<Comment> TGetListByFilter(Expression<Func<Comment, bool>> filter)
        {
            return _commentService.TGetListByFilter(filter);
        }

        public void TInsert(Comment entity)
        {
            _commentService.TInsert(entity);
        }

        public void TUpdate(Comment entity)
        {
            _commentService.TUpdate(entity);
        }
    }
}
