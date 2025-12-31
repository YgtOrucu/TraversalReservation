using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repository;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public EFCommentDal(TraversalContext traversalContext) : base(traversalContext)
        {
        }

        public List<Comment> GetCommentsbyDestinationID(int id)
        {
            return _traversalContext.Comments.Where(x => x.DestinationID == id).ToList();
        }

        public List<Comment> GetCommentsForAdminPage()
        {
            return _traversalContext.Comments.Include(x => x.Destination).ToList();
        }
    }
}
