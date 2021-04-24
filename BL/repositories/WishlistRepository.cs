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
    public class WishlistRepository : BaseRepository<Wishlist>
    {
        public WishlistRepository(DbContext Context) : base(Context)
        {
        }
        public Wishlist GetById(string id)
        {
            return DbSet.Where(w=>w.ID == id).Include(w=>w.Products).FirstOrDefault();
        }

    }
}
