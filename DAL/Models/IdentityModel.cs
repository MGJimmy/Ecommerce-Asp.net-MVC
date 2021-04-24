using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationUserIdentity : IdentityUser
    {
        public ApplicationUserIdentity()
        {
            OrderHeaders = new List<OrderHeader>();
        }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Image { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDay { get; set; }
        [MaxLength(20), MinLength(2)]
        public string Country { get; set; }
        [MaxLength(20), MinLength(2)]
        public string City { get; set; }
        [MaxLength(20), MinLength(2)]
        public string Street { get; set; }
        public string PaymentCard { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Wishlist WishList { get; set; }
        public virtual ICollection<OrderHeader> OrderHeaders { get; set; }
    }
    public class ApplicationUserStore : UserStore<ApplicationUserIdentity>
    {
        public ApplicationUserStore() : base(new ApplicationDBContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
        public bool CheckExist(string userName)
        {
            return Context.Set<ApplicationUserIdentity>().Any(u => u.UserName == userName); ;
        }
    }
    public class ApplicationUserManager : UserManager<ApplicationUserIdentity>
    {
        public ApplicationUserManager() : base(new ApplicationUserStore())
        {

        }
        public ApplicationUserManager(DbContext db) : base(new ApplicationUserStore(db))
        {

        }
        public bool CheckExist(string u)
        {
            return true;
        }
    }
    public class ApplicationRoleStore : RoleStore<IdentityRole>
    {
        public ApplicationRoleStore() : base(new ApplicationDBContext())
        {

        }
        public ApplicationRoleStore(DbContext db) : base(db)
        {

        }
    }
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager()
            : base(new ApplicationRoleStore(new ApplicationDBContext()))
        {

        }
        public ApplicationRoleManager(DbContext db)
            : base(new ApplicationRoleStore(db))
        {

        }
    }
    public class ApplicationDBContext : IdentityDbContext<ApplicationUserIdentity>
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderHeader> OrderHeaders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Wishlist> WishLists { get; set; }
        public virtual DbSet<CartProduct> CartProducts { get; set; }

        public ApplicationDBContext() : base("name=StyleFordCS")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

    
