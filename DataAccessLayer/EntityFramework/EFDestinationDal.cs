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
    public class EFDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public EFDestinationDal(TraversalContext traversalContext) : base(traversalContext) { }
        public int GetDestinationCount()
        {
            return _traversalContext.Destinations.Count();
        }

        public List<Destination> ListingActiveRoutesForMembers()
        {
            return _traversalContext.Destinations.Where(x => x.Status == true).ToList();
        }
    }
}
