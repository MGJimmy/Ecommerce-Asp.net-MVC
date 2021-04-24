using BL.repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Method
        int Commit();
        #endregion

        ColorRepository Color { get; }
        CategoryRepository Category { get; }
        OrderDetailsRepository OrderDetails { get; }
        OrderHeaderRepository OrderHeader { get; }
        ProductRepository Product { get; }
        UserRepository User { get; }
        CartProductRepository CartProduct { get; }
        CartRepository Cart { get; }
        RoleRepository Role { get; }
        WishlistRepository Wishlist { get; }
        EntityState getState(object x);

    }
}
