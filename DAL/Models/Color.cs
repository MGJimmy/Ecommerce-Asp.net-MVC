using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("Color")]
    public class Color
    {
        public Color()
        {
            Products = new List<Product>();
        }
        public int ID { get; set; }

        [Required, Index("ColorName_index", IsUnique = true)]
        [MaxLength(50)]
        public string ColorName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}