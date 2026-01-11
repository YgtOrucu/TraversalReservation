using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repository;
using DTOLayers.DTOs.AnnouncementDTOs;
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

        public List<AnnouncementViewModel> GetByStatus()
        {
            return _traversalContext.Announcements.Where(x => x.Status == true).Select(y => new AnnouncementViewModel
            {
                AnnouncementID = y.AnnouncementID,
                Content = y.Content,
                Title = y.Title
            }).ToList();
        }
    }
}
