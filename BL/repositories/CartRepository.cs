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
    public class CartRepository : BaseRepository<Cart>
    {
        public CartRepository(DbContext Context) : base(Context)
        {
        }
        public Cart GetById(string id)
        {
            return DbSet.Where(c => c.ID == id).Include(c=>c.CartProducts.Select(p=>p.Product)).FirstOrDefault();
        }

    }
}
