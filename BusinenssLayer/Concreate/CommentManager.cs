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
        private readonly ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public List<Comment> TGetAllList()
        {
            return _commentDal.GetAllList();
        }

        public Comment TGetByID(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> TGetCommentsbyDestinationID(int id)
        {
            return _commentDal.GetCommentsbyDestinationID(id);
        }

        public List<Comment> TGetCommentsForAdminPage()
        {
            return _commentDal.GetCommentsForAdminPage();
        }

        public List<Comment> TGetListByFilter(Expression<Func<Comment, bool>> filter)
        {
            return _commentDal.GetListByFilter(filter);
        }

        public void TInsert(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}
