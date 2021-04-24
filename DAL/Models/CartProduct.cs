using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("CartProduct")]
    public class CartProduct
    {
        public int Quantity { get; set; }

        [ForeignKey("Cart"), Key, Column(Order = 1)]
        public string CartID { get; set; }
        public virtual Cart Cart { get; set; }

        [ForeignKey("Product"), Key, Column(Order = 2)]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public double getTotalPrice()
        {
            return Product.Price * Quantity;
        }
    }
}
