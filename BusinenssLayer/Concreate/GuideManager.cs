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
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal _guideDal;
        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }
        public List<Guide> TGetAllList()
        {
            return _guideDal.GetAllList();
        }

        public Guide TGetByID(int id)
        {
            return _guideDal.GetByID(id);
        }

        public List<Guide> TGetListByFilter(Expression<Func<Guide, bool>> filter)
        {
            return _guideDal.GetListByFilter(filter);
        }

        public void TInsert(Guide entity)
        {
            _guideDal.Insert(entity);
        }

        public void TUpdate(Guide entity)
        {
            _guideDal.Update(entity);
        }
    }
}
