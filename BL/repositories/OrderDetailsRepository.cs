using BL.Base;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.repositories
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails>
    {
        public OrderDetailsRepository(DbContext Context) : base(Context)
        {
        }

    }
}
