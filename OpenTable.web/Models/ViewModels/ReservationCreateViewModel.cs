using OpenTable.bus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenTable.web.Models.ViewModels
{
    public class ReservationCreateViewModel
    {
        public Reservation Reservation { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}