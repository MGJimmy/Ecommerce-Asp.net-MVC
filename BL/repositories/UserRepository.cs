using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.repositories
{
    public class UserRepository//: BaseRepository<ApplicationUserIdentity>
    {
        ApplicationUserManager manager;

        public UserRepository(DbContext db)
        {
            manager = new ApplicationUserManager(db);
        }
        public ApplicationUserIdentity Find(string username, string password)
        {
            ApplicationUserIdentity result = manager.Find(username, password);
            return result;
        }
        public ApplicationUserIdentity FindByID(string id)
        {
            return manager.FindById(id);
        }
        public ApplicationUserIdentity FindByUserName(string userName)
        {
            return manager.FindByName(userName);
        }
        public IdentityResult Register(ApplicationUserIdentity user)
        {
            IdentityResult result = manager.Create(user, user.PasswordHash);
            return result;
        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            IdentityResult result = manager.AddToRole(userid, rolename);
            return result;
        }

        public IEnumerable<ApplicationUserIdentity> GetAll()
        {
            return manager.Users.Where(u=>u.IsDeleted == false).ToList();
        }
        
        public IdentityResult Update(ApplicationUserIdentity user)
        {
            
            return manager.Update(user);
        }
        public IdentityResult Delete(ApplicationUserIdentity user)
        {
            return manager.Delete(user);
        }

        public void checkout(string userId, OrderHeader orderHeader)
        {
            ApplicationUserIdentity user = FindByID(userId);
            user.OrderHeaders.Add(orderHeader);
        }

        public IEnumerable<string> GetUserRoles(string userId)
        {
            return manager.GetRoles(userId);
        }
        public bool CheckExist(string userName)
        {
            bool exist = false;
            if (manager.FindByName(userName) != null)
                exist = true;
            return exist;
        }

    }
}
