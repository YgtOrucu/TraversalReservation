using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repository;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        TraversalContext c = new TraversalContext();
        public List<Reservation> GetActiveReservation(int id)
        {
            return c.Reservations.Include(z=>z.Destinations).Where(x => x.AppUserID == id && x.Status == "Onaylandı").OrderByDescending(y => y.Date).ToList();   
        }

        public List<Reservation> GetOldReservation(int id)
        {
            return c.Reservations.Include(z => z.Destinations).Where(x => x.AppUserID == id && x.Status == "Gerçekleşti").OrderByDescending(y => y.Date).ToList();
        }
    }
}

