using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTable.bus.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private List<Restaurant> _restaurants;

        public virtual List<Restaurant> Restaurants
        {
            set { _restaurants = value; }
            get { return _restaurants = _restaurants ?? new List<Restaurant>(); }
        }

        private List<Reservation> _reservations;

        public virtual List<Reservation> Reservations
        {
            set { _reservations = value; }
            get { return _reservations = _reservations ?? new List<Reservation>(); }
        }
    }
}
