using BusinenssLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinenssLayer.Concreate
{
    public class About2Manager : IAbout2Service
    {
        private readonly IAbout2Dal _about2Dal;
        public About2Manager(IAbout2Dal about2Dal)
        {
            _about2Dal = about2Dal;
        }
        public List<About2> TGetAllList()
        {
            return _about2Dal.GetAllList();
        }

        public About2 TGetByID(int id)
        {
            return _about2Dal.GetByID(id);
        }

        public List<About2> TGetListByFilter(Expression<Func<About2, bool>> filter)
        {
            return _about2Dal.GetListByFilter(filter);
        }

        public void TInsert(About2 entity)
        {
            _about2Dal.Insert(entity);
        }

        public void TUpdate(About2 entity)
        {
            _about2Dal.Update(entity);
        }
    }
}
