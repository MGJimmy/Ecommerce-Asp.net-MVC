using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Base;
using DAL;

namespace BL.AppServices
{
    public class OrderHeaderAppService : BaseAppService
    {
        UserAppService userAppService = new UserAppService();
        ProductAppService productAppService = new ProductAppService();
        OrderDetailsAppService orderDetailsAppService = new OrderDetailsAppService();
        public void MakeOrder(string userId, IEnumerable<CartProduct> cartProducts)
        {
            // make orderHeader and add it to the user
            OrderHeader orderHeader = new OrderHeader()
            {
                OrderDate = DateTime.Now
            };
            userAppService.checkout(userId, orderHeader);
            // every product have order details
            foreach (var carProduct in cartProducts)
            {
                OrderDetails orderDetails = new OrderDetails()
                {
                    Quantity = carProduct.Quantity,
                    OrderDate = DateTime.Now,
                    TotalPrice = carProduct.getTotalPrice(),
                    ProductID = carProduct.Product.ID,
                    OrderID = orderHeader.ID
                };
                orderDetailsAppService.Insert(orderDetails);
                AddOrderDetails(orderHeader.ID, orderDetails);
                productAppService.DecreaseQuantity(carProduct.Product.ID, carProduct.Quantity);

            }
            TheUnitOfWork.Commit();
        }

        private void AddOrderDetails(int orderHeaderId, OrderDetails orderDetails)
        {
            OrderHeader orderHeader = GetByID(orderHeaderId);
            orderHeader.AddOrder(orderDetails);
            TheUnitOfWork.Commit();
        }

        public IEnumerable<OrderHeader> GetAll()
        {
            return TheUnitOfWork.OrderHeader.GetAll().ToList();
        }
        public void Insert(OrderHeader OrderHeader)
        {
            TheUnitOfWork.OrderHeader.Insert(OrderHeader);
            TheUnitOfWork.Commit();
        }
        public bool Update(OrderHeader OrderHeader)
        {
            TheUnitOfWork.OrderHeader.Update(OrderHeader);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool Delete(int id)
        {
            bool result = false;

            TheUnitOfWork.OrderHeader.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckExists(OrderHeader OrderHeader)
        {
            return TheUnitOfWork.OrderHeader.GetAny(c => c.ID == OrderHeader.ID);
        }
        public OrderHeader GetByID(int id)
        {
            return TheUnitOfWork.OrderHeader.GetWhere(c => c.ID == id).FirstOrDefault();
        }
        public IEnumerable<OrderHeader> GetAllUserOrdersr(string userId)
        {
            return TheUnitOfWork.OrderHeader.GetWhere(o=>o.ClientID == userId).ToList();
        }
    }
}
