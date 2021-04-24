using BL.Base;
using BL.ViewModels;
using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.AppServices
{
    public class UserAppService : BaseAppService
    {
        #region Get
        public IEnumerable<ApplicationUserIdentity> GetAllUsers()
        {
            return TheUnitOfWork.User.GetAll();
        }
        public IEnumerable<AllUsersVM> GetAllUsersVM()
        {
            var allUsers = TheUnitOfWork.User.GetAll();
            IEnumerable<AllUsersVM> allUsersVMs = Mapper.Map<IEnumerable<AllUsersVM>>(allUsers);
            return allUsersVMs;
        }
        public ApplicationUserIdentity Find(string name, string passworg)
        {
            return TheUnitOfWork.User.Find(name, passworg);
        }
        public ApplicationUserIdentity FindByID(string id)
        {
            return TheUnitOfWork.User.FindByID(id); ;
        }
        public ApplicationUserIdentity FindByUserName(string userName)
        {
            return TheUnitOfWork.User.FindByUserName(userName);
        }
        public UserViewModel GetVMByID(string id)
        {
            ApplicationUserIdentity user = TheUnitOfWork.User.FindByID(id);
            UserViewModel userViewModel = Mapper.Map<UserViewModel>(user);
            return userViewModel;
        }
        public EditlMyProfileVM GetEditMyProfileVM(string id)
        {
            ApplicationUserIdentity user = TheUnitOfWork.User.FindByID(id);
            EditlMyProfileVM editlMyProfileVM = Mapper.Map<EditlMyProfileVM>(user);
            return editlMyProfileVM;
        }
        #endregion
        #region CRUD
        public IdentityResult Register(RegisterViewModel newUser)
        {
            ApplicationUserIdentity identityUser =
                Mapper.Map<ApplicationUserIdentity>(newUser);
            identityUser.Cart = new Cart();
            identityUser.WishList = new Wishlist();
            return TheUnitOfWork.User.Register(identityUser);
        }
        public IdentityResult AddUser(AddUserVM newUser)
        {
            ApplicationUserIdentity identityUser = Mapper.Map<ApplicationUserIdentity>(newUser);
            identityUser.Cart = new Cart();
            identityUser.WishList = new Wishlist();
            return TheUnitOfWork.User.Register(identityUser);
        }
        public void UpdateUser(string userId, UserViewModel userViewModel)
        {
            ApplicationUserIdentity user = TheUnitOfWork.User.FindByID(userId);
            Mapper.Map(userViewModel, user);
            TheUnitOfWork.User.Update(user);
        }
        public IdentityResult DeleteUser(string userId)
        {
            ApplicationUserIdentity user = TheUnitOfWork.User.FindByID(userId);
            TheUnitOfWork.Cart.Delete(user.Cart);
            TheUnitOfWork.Wishlist.Delete(user.WishList);
            TheUnitOfWork.OrderHeader.DeleteList(user.OrderHeaders);
            var result = TheUnitOfWork.User.Delete(user);
            TheUnitOfWork.Commit();
            return result;
        }
        public IdentityResult SoftDeleteUser(string userId)
        {
            ApplicationUserIdentity user = TheUnitOfWork.User.FindByID(userId);
            user.IsDeleted = true;
            return TheUnitOfWork.User.Update(user);
        }
        #endregion
        #region Extra options
        public void EmptyCart(string userId)
        {
            var user = FindByID(userId);
            user.Cart.CartProducts = null;
            TheUnitOfWork.Commit();
        }

        public IdentityResult AssignToRole(string userid, string rolename)
        {
            return TheUnitOfWork.User.AssignToRole(userid, rolename);
        }


        public void UpdateUserShippingInfo(string userId, UserShippingInfoViewModel userShippingInfoViewModel)
        {
            ApplicationUserIdentity user = TheUnitOfWork.User.FindByID(userId);
            Mapper.Map(userShippingInfoViewModel, user);
            TheUnitOfWork.User.Update(user);
        }
        public void checkout(string userId, OrderHeader orderHeader)
        {
            TheUnitOfWork.User.checkout(userId, orderHeader);
            TheUnitOfWork.Commit();
        }
        public bool CheckExist(string userName)
        {
            return TheUnitOfWork.User.CheckExist(userName);
        }

        public void GetUserRoles()
        {

        }
        #endregion
    }
}
