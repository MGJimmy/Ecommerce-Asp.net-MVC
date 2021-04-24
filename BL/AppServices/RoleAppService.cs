using BL.Base;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class RoleAppService : BaseAppService
    {
        public IEnumerable<IdentityRole> GetALL()
        {
            return TheUnitOfWork.Role.GetAll();
        }
        public IdentityRole GetRoleByID(string id)
        {
            return TheUnitOfWork.Role.GetRoleByID(id);
        }
        public IdentityResult Create(string rolename)
        {
            return TheUnitOfWork.Role.Create(rolename);
        }
        
        public void AddOrUpdate(string roleName)
        {
            TheUnitOfWork.Role.AddOrUpdate(roleName);
        }
    }
}
