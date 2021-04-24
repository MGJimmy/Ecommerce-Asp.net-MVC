using BL.ViewModels;
using BL.AppServices;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using DAL;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;

namespace Web.Controllers
{
    [Authorize(Roles ="admin")]
    public class UserController : Controller
    {
        UserAppService userAppService = new UserAppService();
        RoleAppService roleAppService = new RoleAppService();
        public ActionResult Index()
        {
            IEnumerable<AllUsersVM> users = userAppService.GetAllUsersVM();
            return View(users);
        }
        public ActionResult Add() 
        {
            IEnumerable<IdentityRole> roles = roleAppService.GetALL();
            AddUserVM addUserVM = new AddUserVM();
            addUserVM.AllRoles = roles;
            return View(addUserVM);
        } 

        [HttpPost]
        public ActionResult Add(AddUserVM newUser)
        {
            IEnumerable<IdentityRole> roles = roleAppService.GetALL();
            newUser.AllRoles = roles;
            if (ModelState.IsValid == false)
            {
                return View(newUser);
            }
            string roleName= Request["Role"];
            IdentityResult result = userAppService.AddUser(newUser);
            if (result.Succeeded)
            {
                ApplicationUserIdentity identityUser = userAppService.Find(newUser.UserName, newUser.PasswordHash);
                userAppService.AssignToRole(identityUser.Id, roleName);
                TempData["Msg"] = "New User Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault());
                return View(newUser);
            }
        }
        public ActionResult Edit(string id)
        {
   
            UserViewModel user =  userAppService.GetVMByID(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                User.Identity.GetUserId();
                userAppService.UpdateUser(userViewModel.Id, userViewModel);
                TempData["Msg"] = "User updated successfully";
                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }
        public ActionResult Delete(string id)
        {
            IdentityResult result = userAppService.SoftDeleteUser(id);
            if (result.Succeeded)
            {
                TempData["Msg"] = "User deleted successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMsg"] = result.Errors;
                return RedirectToAction("Index");
            }
        }
        [AllowAnonymous]
        public ActionResult Register() => View();

        [HttpPost, AllowAnonymous]
        public ActionResult Register(RegisterViewModel newAccount)
        {
            if (ModelState.IsValid == false)
            {
                return View(newAccount);
            }
            IdentityResult result = userAppService.Register(newAccount);
            if (result.Succeeded)
            {
                IAuthenticationManager owinManager = HttpContext.GetOwinContext().Authentication;
                //SignIn
                SignInManager<ApplicationUserIdentity, string> signInManager =
                    new SignInManager<ApplicationUserIdentity, string>(
                        new ApplicationUserManager(), owinManager
                        );
                ApplicationUserIdentity identityUser = userAppService.Find(newAccount.UserName, newAccount.PasswordHash);
                signInManager.SignIn(identityUser, true, true);
                TempData["Msg"] = "Register complete successfully";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault());
                return View(newAccount);
            }
        }
        [AllowAnonymous]
        public ActionResult Login() => View();

        [HttpPost, AllowAnonymous]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid == false)
            {
                return View(user);
            }
            ApplicationUserIdentity identityUser = userAppService.Find(user.UserName, user.PasswordHash);

            if (identityUser != null)
            {
                IAuthenticationManager owinManager = HttpContext.GetOwinContext().Authentication;
                //SignIn
                SignInManager<ApplicationUserIdentity, string> signInManager =
                    new SignInManager<ApplicationUserIdentity, string>(
                        new ApplicationUserManager(), owinManager
                        );
                signInManager.SignIn(identityUser, true, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Not Valid Username & Password");
                return View(user);
            }

        }
        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager owinManager = HttpContext.GetOwinContext().Authentication;
            owinManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
        [Authorize]
        public ActionResult EditMyProfile()
        {
            string userId = User.Identity.GetUserId();
            EditlMyProfileVM editlMyProfileVM = userAppService.GetEditMyProfileVM(userId);
            return View(editlMyProfileVM);
        }

    }
}