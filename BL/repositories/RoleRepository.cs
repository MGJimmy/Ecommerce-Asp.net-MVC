using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.repositories
{
    public class RoleRepository
    {
        ApplicationRoleManager manager;
        public RoleRepository(DbContext db)
        {
            manager = new ApplicationRoleManager(db);
        }

        public IdentityResult Create(string role)
        {
            return manager.CreateAsync(new IdentityRole(role)).Result;
        }
        public IEnumerable<IdentityRole> GetAll()
        {
            return manager.Roles;
        }
        public IdentityRole GetRoleByID(string id)
        {
            return manager.FindById(id);
        }
        public void AddOrUpdate(string roleName)
        {
            if (manager.RoleExists(roleName))
            {
                return;
            }
            else
            {
                Create(roleName);
            }
        }
    }
}
