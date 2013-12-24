using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTable.bus.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private List<User> _users;

        public List<User> Users
        {
            set { _users = value; }
            get { return _users = _users ?? new List<User>(); }
        }

        private List<Reservation> _reservations;

        public List<Reservation> Reservations
        {
            set { _reservations = value; }
            get { return _reservations = _reservations ?? new List<Reservation>(); }
        }

    }
}
