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
    public class DestinationManager : IDestinationService
    {
        private readonly IDestinationDal _destinationDal;
        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public List<Destination> TGetAllList()
        {
            return _destinationDal.GetAllList();
        }

        public Destination TGetByID(int id)
        {
            return _destinationDal.GetByID(id);
        }

        public int TGetDestinationCount()
        {
            return _destinationDal.GetDestinationCount();
        }

        public List<Destination> TGetListByFilter(Expression<Func<Destination, bool>> filter)
        {
            return _destinationDal.GetListByFilter(filter);
        }

        public void TInsert(Destination entity)
        {
            _destinationDal.Insert(entity);
        }

        public void TUpdate(Destination entity)
        {
            _destinationDal.Update(entity);
        }
    }
}
