using AutoMapper;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Meals;
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
                .ForMember(a => a.Photo, b => b.Ignore())
                .ReverseMap();
            CreateMap<Meal, MealDTO>().ReverseMap();
            CreateMap<AppUser, AppUserDTO>()
                .ForMember(a => a.ConfirmPassword, b => b.Ignore())
                .ForMember(a => a.RememberMe, b => b.Ignore())
                .ForMember(a => a.Password, b => b.MapFrom(c => c.PasswordHash))
                .ReverseMap();
            CreateMap<Diet, DietDTO>()
                .ForMember(a => a.Days, b => b.MapFrom(c => c.DietDays))
                .ReverseMap();
            CreateMap<Day, DayDTO>()
                .ReverseMap();
            CreateMap<MealFormDTO, Meal>()
                //.AfterMap((src, dest) =>
                //{
                //    foreach (var product in src.MealProducts)
                //    {
                //        dest.MealProducts.Add(new MealProduct() { ProductId = product.ProductId, Quantity = product.Quantity });
                //    }
                //})
                .ForMember(a => a.TypeOfMeal, b => b.MapFrom(c => c.TypeOfMeal))
                .ForMember(a => a.UserId, b => b.MapFrom(c => c.UserId))
                .ForMember(a => a.MealName, b => b.MapFrom(c => c.MealName))
                .ForMember(a=>a.MealProducts, b=>b.MapFrom(c=>c.MealProducts))
                .ForMember(a=>a.Id, b=>b.MapFrom(c=>c.Id))
                .ForMember(a=>a.Description, b=>b.MapFrom(c=>c.Description))
                .ForAllOtherMembers(a => a.Ignore());

        }
    }
}
