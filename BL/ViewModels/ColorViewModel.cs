using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class ColorViewModel
    {
        public int ID { get; set; }

        [Required]
        public string ColorName { get; set; }
    }
}
