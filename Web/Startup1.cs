using BL.AppServices;
using BL.ViewModels;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Web.Startup1))]

namespace Web
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions()
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    ExpireTimeSpan = TimeSpan.FromHours(1),
                    LoginPath = new PathString(@"/User/Login")

                });
            app.MapSignalR();
            AddFirstAdminAndRoles();
        }
        private void AddFirstAdminAndRoles()
        {
            UserAppService userAppService = new UserAppService();
            RoleAppService roleAppService = new RoleAppService();
            roleAppService.AddOrUpdate("admin");
            roleAppService.AddOrUpdate("client");
            RegisterViewModel user = new RegisterViewModel()
            {
                FirstName = "first",
                LastName ="user",
                UserName = "admin",
                PasswordHash = "admin12345"
            };
            if (!userAppService.CheckExist("admin"))
            {
                userAppService.Register(user);
                ApplicationUserIdentity registeredUser = userAppService.FindByUserName(user.UserName);
                userAppService.AssignToRole(registeredUser.Id, "admin");
            }            
        }

    }
}
