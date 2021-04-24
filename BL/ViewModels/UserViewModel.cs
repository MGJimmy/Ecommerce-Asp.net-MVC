using DAL;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }
        [DataType(DataType.PhoneNumber)]
        public virtual string PhoneNumber { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        public ICollection<IdentityUserRole> Roles { get; }

    }
}
