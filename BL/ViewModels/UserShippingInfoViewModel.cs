using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class UserShippingInfoViewModel
    {
        [MaxLength(20), MinLength(2)]
        public string Country { get; set; }
        [MaxLength(20), MinLength(2)]
        public string City { get; set; }
        [MaxLength(20), MinLength(2)]
        public string Street { get; set; }
        public string PaymentCard { get; set; }
    }
}
