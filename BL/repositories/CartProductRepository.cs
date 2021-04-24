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
    public class CartProductRepository : BaseRepository<CartProduct>
    {
        public CartProductRepository(DbContext Context) : base(Context)
        {
        }

        public CartProduct GetCartProduct(string cartId, int productId)
        {
            return DbSet.Where(c => c.CartID == cartId && c.ProductID == productId).FirstOrDefault();
        }


    }
}
