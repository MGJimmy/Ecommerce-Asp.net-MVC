using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Wishlist
    {
        public Wishlist()
        {
            Products = new List<Product>();
        }
        [Key, ForeignKey("User")]
        public string ID { get; set; }

        public virtual ApplicationUserIdentity User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
