using OpenTable.bus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenTable.web.Models.ViewModels
{
    public class SelectedRestaurant
    {
        public Restaurant Restaurant { set; get; }
        public bool Selected { get; set; }
    }
}