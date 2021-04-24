using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Password")]

        public string PasswordHash { get; set; }
    }
}
