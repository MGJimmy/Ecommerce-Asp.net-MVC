using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public enum Status
    {
        InStock,
        OutofStock,
        orderBack
    }
    public class AddProductVM
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string MainImage { get; set; }
        public string SecondaryImage { get; set; }
        public string AnotherImage { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double PriceSale { get; set; }
        public Status Status { get; set; }

        [MinLength(10), MaxLength(300)]
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int ColorID { get; set; }
        public IEnumerable<Color> Colors { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
