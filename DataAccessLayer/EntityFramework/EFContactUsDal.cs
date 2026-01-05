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
    public class EFContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public EFContactUsDal(TraversalContext traversalContext) : base(traversalContext)
        {
        }

        public List<ContactUs> GetListTRUE()
        {
            return  _traversalContext.ContactUs.Where(x => x.Status == true).ToList();
        }
    }
}
