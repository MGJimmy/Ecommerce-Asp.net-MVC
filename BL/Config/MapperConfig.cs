using AutoMapper;
using BL.ViewModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configur
{
    public static class MapperConfig
    {
        public static IMapper Mapper { get; set; }
        static MapperConfig()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<ApplicationUserIdentity, LoginViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, RegisterViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, UserViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, AddUserVM>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, AllUsersVM>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, UserShippingInfoViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUserIdentity, EditlMyProfileVM>().ReverseMap();
                    cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();
                    cfg.CreateMap<Color, ColorViewModel>().ReverseMap();
                    cfg.CreateMap<Product, AddProductVM>().ReverseMap();

                });
            Mapper = config.CreateMapper();
        }
    }
}
