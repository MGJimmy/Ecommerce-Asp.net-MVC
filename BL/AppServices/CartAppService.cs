using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Base;
using DAL;

namespace BL.AppServices
{
    public class CartAppService : BaseAppService
    {
        public bool addProduct(CartProduct cartProduct)
        {
            Cart cart = TheUnitOfWork.Cart.GetById(cartProduct.CartID);
            bool find = false;
            bool productAdded = false;
            foreach (var item in cart.CartProducts)
            {
                if (item.ProductID == cartProduct.ProductID)
                { find = true; }
            }
            if (!find)
            {
                cart.CartProducts.Add(cartProduct);
                TheUnitOfWork.Commit();
                productAdded = true;

            }
            return productAdded;
        }
        public void removeProduct(string userId ,int productId)
        {
            Cart cart = TheUnitOfWork.Cart.GetById(userId);
            CartProduct cartProduct = TheUnitOfWork.CartProduct.GetCartProduct(cart.ID, productId);
            cart.CartProducts.Remove(cartProduct);
            TheUnitOfWork.Commit();
        }

        public Cart getCartByUserId(string userId)
        {
            return TheUnitOfWork.Cart.GetById(userId);
        }
        public double getCartProductsPrice(string userId)
        {
            Cart cart = getCartByUserId(userId);
            double totalPrice = 0;
            foreach (var cartProduct in cart.CartProducts)
            {
                totalPrice += cartProduct.Product.Price * cartProduct.Quantity;
            }
            return totalPrice;
        }

    }
}
