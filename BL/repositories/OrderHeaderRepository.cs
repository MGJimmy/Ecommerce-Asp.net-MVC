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
    public class OrderHeaderRepository : BaseRepository<OrderHeader>
    {
        public OrderHeaderRepository(DbContext Context) : base(Context)
        {
        }

    }
}
