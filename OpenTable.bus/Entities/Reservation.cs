using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTable.bus.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string SpecialRequest { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
    }
}
