using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    public enum Status
    {
        InStock,
        OutofStock,
        orderBack
    }
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            WishLists = new List<Wishlist>();
            OrderDetails = new List<OrderDetails>();
            CartProducts = new List<CartProduct>();
        }
        public int ID { get; set; }
        [Required, MinLength(3)]
        public string Name { get; set; }
        [MinLength(10), MaxLength(300)]
        public string Description { get; set; }
        public int Rate { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double PriceSale { get; set; }
        public string MainImage { get; set; }
        public string SecondaryImage { get; set; }
        public string AnotherImage { get; set; }
        [Required]
        public Status Status { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("Color")]
        public int ColorID { get; set; }
        public virtual Color Color { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual ICollection<Wishlist> WishLists { get; set; }

    }
}