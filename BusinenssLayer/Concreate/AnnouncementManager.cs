using BusinenssLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayers.DTOs.AnnouncementDTOs;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinenssLayer.Concreate
{
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public List<Announcement> TGetAllList()
        {
            return _announcementDal.GetAllList();
        }

        public Announcement TGetByID(int id)
        {
            return _announcementDal.GetByID(id);
        }

        public List<AnnouncementViewModel> TGetByStatus()
        {
            return _announcementDal.GetByStatus();
        }

        public List<Announcement> TGetListByFilter(Expression<Func<Announcement, bool>> filter)
        {
            return _announcementDal.GetListByFilter(filter);
        }

        public void TInsert(Announcement entity)
        {
            _announcementDal.Insert(entity);
        }

        public void TUpdate(Announcement entity)
        {
            _announcementDal.Update(entity);
        }
    }
}
