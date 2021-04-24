using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class EditlMyProfileVM
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        public string Image { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Compare("PasswordHash", ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; }
    }
}
