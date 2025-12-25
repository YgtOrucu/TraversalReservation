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
    public class SubAboutManager : ISubAboutService
    {
        private readonly ISubAboutDal _subAboutDal;
        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }
        public List<SubAbout> TGetAllList()
        {
            return _subAboutDal.GetAllList();
        }

        public SubAbout TGetByID(int id)
        {
            return _subAboutDal.GetByID(id);
        }

        public List<SubAbout> TGetListByFilter(Expression<Func<SubAbout, bool>> filter)
        {
            return _subAboutDal.GetListByFilter(filter);
        }

        public void TInsert(SubAbout entity)
        {
            _subAboutDal.Insert(entity);
        }

        public void TUpdate(SubAbout entity)
        {
            _subAboutDal.Update(entity);
        }
    }
}
