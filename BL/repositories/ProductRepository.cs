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
    public class ProductRepository : BaseRepository<Product>
    {

        public ProductRepository(DbContext Context) : base(Context)
        {
        }
        public virtual IEnumerable<Product> GetAllProducts()
        {
            return GetAll();
        }
        public void AssignColorToProduct(Product product, Color color)
        {
            color.Products.Add(product);
        }
        
        public IEnumerable<Product> GetProductsByColor(int colorId)
        {
            return GetWhere(p => p.ColorID == colorId);
        }
        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return GetWhere(p => p.CategoryID == categoryId);
        }

        public IEnumerable<Product> GetLastProducts(int number = 0)
        {
            if(number <= 0)
                return GetAllSortedDesc(p => p.ID);
            else
                return GetAllSortedDesc(p => p.ID).Take(number);
        }
        public void addOrderDetails(Product product ,OrderDetails orderDetails)
        {
            product.OrderDetails.Add(orderDetails);
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return GetWhere(p => p.Name.Contains(name));
        }
    }
}
