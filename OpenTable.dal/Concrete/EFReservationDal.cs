using OpenTable.bus.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTable.dal.Concrete
{
    public class EFReservationDal : IReservationDal
    {
        private OpenTableDB _ctx;

        private OpenTableDB ctx
        {
            get
            {
                if (_ctx == null)
                    _ctx = new OpenTableDB();
                return _ctx;
            }
        }

        public IQueryable<bus.Entities.Reservation> Reservations
        {
            get { return ctx.Reservations; }
        }

        public bus.Entities.Reservation Set(bus.Entities.Reservation reservation)
        {
            ctx.Reservations.Attach(reservation);
            ctx.Entry(reservation).State = reservation.Id == 0 ? System.Data.EntityState.Added : System.Data.EntityState.Modified;
            ctx.SaveChanges();
            return reservation;
        }

        public void Destroy(bus.Entities.Reservation reservation)
        {
            ctx.Reservations.Attach(reservation);
            ctx.Entry(reservation).State = System.Data.EntityState.Deleted;
            ctx.SaveChanges();
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}
