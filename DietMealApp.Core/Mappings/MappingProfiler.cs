using AutoMapper;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Mappings
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(a=>a.Photo, b=>b.Ignore())
                .ReverseMap();
            CreateMap<Meal, MealDTO>().ReverseMap();
            CreateMap<AppUser, AppUserDTO>()
                .ForMember(a=>a.ConfirmPassword, b=>b.Ignore())
                .ForMember(a=>a.RememberMe, b=>b.Ignore())
                .ForMember(a=>a.Password, b=>b.MapFrom(c=>c.PasswordHash))
                .ReverseMap();
            CreateMap<Diet, DietDTO>().ReverseMap();
            CreateMap<DietDay, DietDayDTO>()
                .ReverseMap();
        }
    }
}
