using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Base;
using DAL;

namespace BL.AppServices
{
    public class CartProductAppService : BaseAppService
    {
        public CartProduct GetCartProduct(string cartId, int productId)
        {
            return TheUnitOfWork.CartProduct.GetCartProduct(cartId, productId);
        }
        public void UpdateQuantity(string cartId, int productId, int quantity)
        {
            CartProduct cartProduct = GetCartProduct(cartId, productId);
            cartProduct.Quantity = quantity;
            TheUnitOfWork.Commit();
        }
    }
}
