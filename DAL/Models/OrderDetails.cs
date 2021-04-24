using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        public int ID { get; set; }
        public int Quantity { get; set; }  // on migiration (defaultValue: true)
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        [NotMapped]
        public double NetPrice 
        {
            get { return TotalPrice - Discount; }
            private set { } 
        }
        [ForeignKey("Product")]
        public int? ProductID { get; set; }
        [ForeignKey("OrderHeader")]
        public int? OrderID { get; set; }

        public virtual Product Product { get; set; }
        public virtual OrderHeader OrderHeader { get; set; }
    }
}