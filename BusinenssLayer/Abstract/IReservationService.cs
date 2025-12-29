using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinenssLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        List<Reservation> TGetActiveReservation(int id);
        List<Reservation> TGetOldReservation(int id);
    }
}
