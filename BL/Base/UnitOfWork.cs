using BL.Interfaces;
using BL.repositories;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Common Properties
        private DbContext EC_DbContext { get; set; }

        #endregion

        #region Constructors
        public UnitOfWork()
        {
            EC_DbContext = new ApplicationDBContext();
            // Avoid load navigation properties
            //EC_DbContext.Configuration.LazyLoadingEnabled = false;
        }
        #endregion

        #region Methods
        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }

        public void Dispose()
        {
            EC_DbContext.Dispose();
        }
        #endregion
        public EntityState getState(object x)
        {
            return EC_DbContext.Entry(x).State;
        }
        private ColorRepository color;
        public ColorRepository Color
        {
            get
            {
                if (color == null)
                    color = new ColorRepository(EC_DbContext);
                return color;
            }
        }

        private CategoryRepository category;
        public CategoryRepository Category 
        {
            get
            {
                if (category == null)
                    category = new CategoryRepository(EC_DbContext);
                return category;
            }
        }

        private OrderDetailsRepository orderDetails;
        public OrderDetailsRepository OrderDetails
        {
            get
            {
                if (orderDetails == null)
                    orderDetails = new OrderDetailsRepository(EC_DbContext);
                return orderDetails;
            }
        }

        private OrderHeaderRepository orderHeader;
        public OrderHeaderRepository OrderHeader
        {
            get
            {
                if (orderHeader == null)
                    orderHeader = new OrderHeaderRepository(EC_DbContext);
                return orderHeader;
            }
        }

        private ProductRepository product;
        public ProductRepository Product
        {
            get
            {
                if (product == null)
                    product = new ProductRepository(EC_DbContext);
                return product;
            }
        }

        private UserRepository user;
        public UserRepository User
        {
            get
            {
                if (user == null)
                    user = new UserRepository(EC_DbContext);
                return user;
            }
        }
        private CartProductRepository cartProduct;
        public CartProductRepository CartProduct
        {
            get
            {
                if (cartProduct == null)
                    cartProduct = new CartProductRepository(EC_DbContext);
                return cartProduct;
            }
        }
        private CartRepository cart;
        public CartRepository Cart
        {
            get
            {
                if (cart == null)
                    cart = new CartRepository(EC_DbContext);
                return cart;
            }
        }
        private RoleRepository role;
        public RoleRepository Role
        {
            get
            {
                if (role == null)
                    role = new RoleRepository(EC_DbContext);
                return role;
            }
        }
        private WishlistRepository wishlist;
        public WishlistRepository Wishlist
        {
            get
            {
                if (wishlist == null)
                    wishlist = new WishlistRepository(EC_DbContext);
                return wishlist;
            }
        }
        

    }
}
