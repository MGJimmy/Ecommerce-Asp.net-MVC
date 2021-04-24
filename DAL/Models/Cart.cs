using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Cart")]
    public class Cart
    {
        public Cart()
        {
            CartProducts = new List<CartProduct>();
        }
        [Key, ForeignKey("User")]
        public string ID { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual ApplicationUserIdentity User { get; set; }
    }
}
