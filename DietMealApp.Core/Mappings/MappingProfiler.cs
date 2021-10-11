using AutoMapper;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
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
                .ForMember(a => a.MealProducts, b => b.MapFrom(c => c.MealProducts))
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.Description, b => b.MapFrom(c => c.Description))
                .ForAllOtherMembers(a => a.Ignore());
            CreateMap<MealMenuItemDTO, DayMeals>()
                .ForMember(a => a.MealId, b => b.MapFrom(c => c.SelectedMeal))
                .ForMember(a => a.Type, b => b.MapFrom(c => c.AssignedMealTimeType))
                .ForAllOtherMembers(a => a.Ignore());
            CreateMap<DayMeals, MealMenuItemDTO>()
                .ForMember(a => a.SelectedMeal, b => b.MapFrom(c => c.MealId))
                .ForMember(a => a.AssignedMealTimeType, b => b.MapFrom(c => c.Type))
                .ForAllOtherMembers(a => a.Ignore());
            CreateMap<DayFormDTO, Day>()
                .ForMember(a => a.DayMeals, b => b.MapFrom(c => c.MealItems))
                .ForMember(a => a.NumberOfMeals, b => b.MapFrom(c => c.MealsCount))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name))
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForAllOtherMembers(a => a.Ignore());
            CreateMap<Day, DayFormDTO>()
                .ForMember(a => a.MealItems, b => b.MapFrom(c => c.DayMeals))
                .ForMember(a => a.MealsCount, b => b.MapFrom(c => c.NumberOfMeals))
                .ForMember(a => a.Name, b => b.MapFrom(c => c.Name))
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForAllOtherMembers(a => a.Ignore());
        }
    }
}
