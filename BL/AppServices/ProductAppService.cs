using BL.Base;
using BL.ViewModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class ProductAppService : BaseAppService
    {
        public IEnumerable<Product> GetAll()
        {
            List<Product> products = TheUnitOfWork.Product.GetAllProducts().ToList();
            return products;
        }
        public Product GetById(int id)
        {
            return TheUnitOfWork.Product.GetById(id);
        }
        public void Insert(AddProductVM ProductViewModel)
        {
            var product = Mapper.Map<Product>(ProductViewModel);
            TheUnitOfWork.Product.Insert(product);
            TheUnitOfWork.Commit();
        }
        public bool Update(AddProductVM ProductViewModel)
        {
            var product = Mapper.Map<Product>(ProductViewModel);
            TheUnitOfWork.Product.Update(product);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool Delete(int id)
        {
            bool result = false;

            TheUnitOfWork.Product.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckExists(AddProductVM productViewModel)
        {
            var product = Mapper.Map<Product>(productViewModel);
            return TheUnitOfWork.Product.GetAny(c => c.ID == product.ID);
        }

        internal void DecreaseQuantity(int Id, int quantity)
        {
            Product product = GetById(Id);
            product.Quantity -= quantity;
            TheUnitOfWork.Commit();
        }

        public bool AssignColorToProduct(Product product, int colorId)
        {
            Color color =  TheUnitOfWork.Color.GetById(colorId);
            TheUnitOfWork.Product.AssignColorToProduct(product, color);
            return TheUnitOfWork.Commit() > new int();
        }
        public IEnumerable<Product> GetProductsByColor(int colorId) 
        {
            return TheUnitOfWork.Product.GetProductsByColor(colorId).ToList();
        }
        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return TheUnitOfWork.Product.GetProductsByCategory(categoryId).ToList();
        }
        public IEnumerable<Product> GetLastProducts(int number = 0)
        {
            return TheUnitOfWork.Product.GetLastProducts(number).ToList();
        }
        public void addOrderDetails(int productId, int orderDetailsId)
        {
            Product product = GetById(productId);
            OrderDetails orderDetails = TheUnitOfWork.OrderDetails.GetById(orderDetailsId);
            TheUnitOfWork.Product.addOrderDetails(product, orderDetails);
            TheUnitOfWork.Commit();
        }
        public IEnumerable<Product> searchByName(string name)
        {

            return TheUnitOfWork.Product.GetProductsByName(name).ToList();

        }
    }
}
