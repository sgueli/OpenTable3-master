using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTable.bus.Entities;

namespace OpenTable.bus.Abstract
{
    public interface IRestaurantDal
    {
        IQueryable<Restaurant> Restaurants { get; }
        Restaurant Set(Restaurant restaurant);
        void Destroy(Restaurant restaurant);
        void Dispose();
    }
}
