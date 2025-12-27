using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repository;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        TraversalContext c = new TraversalContext();
        public List<Comment> GetCommentsbyDestinationID(int id)
        {
            return c.Comments.Where(x => x.DestinationID == id).ToList();
        }
    }
}
