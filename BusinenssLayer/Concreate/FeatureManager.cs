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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;
        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }
        public List<Feature> TGetAllList()
        {
            return _featureDal.GetAllList();
        }

        public Feature TGetByID(int id)
        {
            return _featureDal.GetByID(id);
        }

        public List<Feature> TGetListByFilter(Expression<Func<Feature, bool>> filter)
        {
            return _featureDal.GetListByFilter(filter);
        }

        public void TInsert(Feature entity)
        {
            _featureDal.Insert(entity);
        }

        public void TUpdate(Feature entity)
        {
            _featureDal.Update(entity);
        }
    }
}
