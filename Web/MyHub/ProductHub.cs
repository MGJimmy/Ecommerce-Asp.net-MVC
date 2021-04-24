using BL.AppServices;
using DAL;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Web.MyHub
{
    [HubName("ProductHub")]
    public class ProductHub : Hub
    {
        CartAppService cartAppService = new CartAppService();
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        [HubMethodName("DecreaseQuantity")]
        public void DecreaseQuantity(string userId)
        {
            Cart userCart = cartAppService.getCartByUserId(userId);
            foreach (var cartProduct in userCart.CartProducts)
            {
                var newQuantity = cartProduct.Product.Quantity - cartProduct.Quantity; 
                Clients.All.NewQuantity(cartProduct.ProductID, newQuantity);
            }
        }

    }
}