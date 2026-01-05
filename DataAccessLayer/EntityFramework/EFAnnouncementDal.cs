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
    public class EFAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public EFAnnouncementDal(TraversalContext traversalContext) : base(traversalContext)
        {
        }
    }
}
