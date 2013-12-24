using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTable.dal.Concrete
{
    public class EFUserDal : OpenTable.bus.Abstract.IUserDal
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

        public IQueryable<bus.Entities.User> Users
        {
            get { return ctx.Users; }
        }

        public bus.Entities.User Set(bus.Entities.User user)
        {
            //ctx.Users.Attach(user);
            if (user.Id == 0)
            {
                ctx.Users.Add(user);
                foreach (var rest in user.Restaurants)
                    ctx.Restaurants.Attach(rest);
 
            }
            else
            {
                var existing = ctx.Users.Include("Restaurants").SingleOrDefault(u => u.Id == user.Id);

                ctx.Entry(existing).CurrentValues.SetValues(user);

                foreach (var rest in existing.Restaurants.ToList())
                {
                    if (!user.Restaurants.Any(r => r.Id == rest.Id))
                    {
                        existing.Restaurants.Remove(rest);
                    }
                }

                foreach (var rest in user.Restaurants)
                {
                    if (!existing.Restaurants.Any(r => rest.Id == r.Id))
                    {
                        ctx.Restaurants.Attach(rest);
                        existing.Restaurants.Add(rest);
                    }
                }
            }
            ctx.SaveChanges();
            return user;
        }

        public void Destroy(bus.Entities.User user)
        {
            ctx.Users.Attach(user);
            ctx.Entry(user).State = System.Data.EntityState.Deleted;
            ctx.SaveChanges();
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}
