using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTable.bus.Abstract
{
    public interface IUserDal
    {
        IQueryable<Entities.User> Users { get; }
        Entities.User Set(Entities.User user);
        void Destroy(Entities.User user);
        void Dispose();
    }
}
