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
        TraversalContext context = new TraversalContext();
        public int GetDestinationCount()
        {
            return context.Destinations.Count();
        }

        public List<Destination> ListingActiveRoutesForMembers()
        {
            return context.Destinations.Where(x => x.Status == true).ToList();
        }
    }
}
