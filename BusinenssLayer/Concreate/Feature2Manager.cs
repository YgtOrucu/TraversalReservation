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
    public class Feature2Manager : IFeature2Service
    {
        private readonly IFeature2Dal _feature2Dal;
        public Feature2Manager(IFeature2Dal feature2Dal)
        {
            _feature2Dal = feature2Dal;
        }
        public List<Feature2> TGetAllList()
        {
            return _feature2Dal.GetAllList();
        }

        public Feature2 TGetByID(int id)
        {
            return _feature2Dal.GetByID(id);
        }

        public List<Feature2> TGetListByFilter(Expression<Func<Feature2, bool>> filter)
        {
            return _feature2Dal.GetListByFilter(filter);
        }

        public void TInsert(Feature2 entity)
        {
            _feature2Dal.Insert(entity);
        }

        public void TUpdate(Feature2 entity)
        {
            _feature2Dal.Update(entity);
        }
    }
}
