using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Base;
using DAL;

namespace BL.AppServices
{
    public class OrderDetailsAppService : BaseAppService
    {
        public IEnumerable<OrderDetails> GetAll()
        {
            return TheUnitOfWork.OrderDetails.GetAll().ToList();
        }
        public void Insert(OrderDetails OrderDetails)
        {
            TheUnitOfWork.OrderDetails.Insert(OrderDetails);
            TheUnitOfWork.Commit();
        }
        public bool Update(OrderDetails OrderDetails)
        {
            TheUnitOfWork.OrderDetails.Update(OrderDetails);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool Delete(int id)
        {
            bool result = false;

            TheUnitOfWork.OrderDetails.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckExists(OrderDetails OrderDetails)
        {
            return TheUnitOfWork.OrderDetails.GetAny(c => c.ID == OrderDetails.ID);
        }
        public OrderDetails GetByID(int id)
        {
            return TheUnitOfWork.OrderDetails.GetWhere(c => c.ID == id).FirstOrDefault();
        }
       
    }
}
