using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("OrderHeader")]
    public class OrderHeader
    {
        public OrderHeader()
        {
            OrderDetails = new List<OrderDetails>();
        }
        public int ID { get; set; }
        [ForeignKey("Client")]
        public string ClientID { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public double CouponDiscount { get; set; }
        [NotMapped]
        public double? NetPrice 
        {
            get { return TotalPrice - CouponDiscount; }
            private set { }
        }
        public int ItemsCount { get; set; }

        public virtual ApplicationUserIdentity Client { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; private set; }

        public void AddOrder(OrderDetails order)
        {
            TotalPrice += order.TotalPrice;
            ItemsCount += order.Quantity;
        }

    }
}