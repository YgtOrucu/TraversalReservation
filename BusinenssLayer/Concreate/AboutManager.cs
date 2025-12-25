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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public List<About> TGetAllList()
        {
            return _aboutDal.GetAllList();
        }

        public About TGetByID(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public List<About> TGetListByFilter(Expression<Func<About, bool>> filter)
        {
            return _aboutDal.GetListByFilter(filter);
        }

        public void TInsert(About entity)
        {
            _aboutDal.Insert(entity);
        }

        public void TUpdate(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
