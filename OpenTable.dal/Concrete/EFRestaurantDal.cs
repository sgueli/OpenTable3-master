using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTable.bus.Abstract;
using OpenTable.bus.Entities;

namespace OpenTable.dal.Concrete
{
    public class EFRestaurantDal : IRestaurantDal
    {
        private OpenTableDB _ctx;

        private OpenTableDB ctx
        {
            get {
                if (_ctx == null)
                    _ctx = new OpenTableDB();
                return _ctx;
            }
        }
        public IQueryable<Restaurant> Restaurants
        {
            get { return ctx.Restaurants; }
        }

        public Restaurant Set(Restaurant restaurant)
        {
            ctx.Restaurants.Attach(restaurant);
            if (restaurant.Id == 0)
            {
                ctx.Entry(restaurant).State = System.Data.EntityState.Added;
            }
            else
            {
                ctx.Entry(restaurant).State = System.Data.EntityState.Modified;
            }
            ctx.SaveChanges();
            return restaurant;
        }

        public void Destroy(Restaurant restaurant)
        {
            ctx.Restaurants.Attach(restaurant);
            ctx.Entry(restaurant).State = System.Data.EntityState.Deleted;
            ctx.SaveChanges();
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}
