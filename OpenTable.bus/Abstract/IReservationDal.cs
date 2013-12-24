using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTable.bus.Entities;

namespace OpenTable.bus.Abstract
{
    public interface IReservationDal
    {
        IQueryable<Reservation> Reservations { get; }
        Reservation Set(Reservation reservation);
        void Destroy(Reservation reservation);
        void Dispose();
    }
}
