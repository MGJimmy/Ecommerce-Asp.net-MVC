using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int ID { get; set; }

        [Required, Index("CategoryName_index",IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}