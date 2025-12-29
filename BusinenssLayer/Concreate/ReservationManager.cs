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
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }


        public List<Reservation> TGetAllList()
        {
            return _reservationDal.GetAllList();
        }

        public Reservation TGetByID(int id)
        {
            return _reservationDal.GetByID(id);
        }

        public List<Reservation> TGetListByFilter(Expression<Func<Reservation, bool>> filter)
        {
            return _reservationDal.GetListByFilter(filter);
        }

        public List<Reservation> TGetActiveReservation(int id)
        {
            return _reservationDal.GetActiveReservation(id);
        }

        public List<Reservation> TGetOldReservation(int id)
        {
            return _reservationDal.GetOldReservation(id);
        }

        public void TInsert(Reservation entity)
        {
            _reservationDal.Insert(entity);
        }

        public void TUpdate(Reservation entity)
        {
            _reservationDal.Update(entity);
        }
    }
}
