using DietMealApp.Application.Functions.Diet.Query.GetDietsByUser;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Interfaces;
using DietMealApp.DataAccessLayer.Repositories;
using DietMealApp.Service.Functions.Query;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietMealApp.Application.Functions.Day.Query.GetDaysByIds;
using DietMealApp.Core.DTO.Menu;
using DietMealApp.Application.Functions.Menu.Query.GetMenuForm;
using DietMealApp.Application.Functions.Menu.Query.GetMenuForWeek;
using DietMealApp.Core.ViewModels;
using DietMealApp.Application.Functions.Shopping.Query.GetShoppingListById;
using DietMealApp.Application.Functions.Shopping.Query.GetAllShoppingLists;
using DietMealApp.Application.Functions.Shopping.Query.GetShoppingListBySearch;
using DietMealApp.Application.Functions.Shopping.Command.DeleteShoppingList;
using DietMealApp.Application.Functions.Shopping.Command.InsertShoppingList;
using DietMealApp.Application.Functions.Shopping.Command.UpdateShoppingList;
using DietMealApp.Core.DTO.ShoppingList;
using DietMealApp.Application.Functions.Meal.Command.InsertMeal;
using DietMealApp.Core.DTO.Meals;
using DietMealApp.Application.Functions.Meal.Query.GetMealById;
using DietMealApp.Application.Functions.Meal.Command.UpdateMeal;
using DietMealApp.Application.Functions.Meal.Command.DeleteMeal;
using DietMealApp.Application.Functions.DietDay.Query.GetDaysByUser;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Application.Functions.Meal.Query.GetMealsByType;
using Microsoft.AspNetCore.Mvc.Rendering;
using DietMealApp.Application.Functions.Meal.Query.GetMealsBySearch;
using DietMealApp.Application.Functions.Product.Query.GetProductsBySearch;
using DietMealApp.Application.Functions.Day.Command.InsertDay;
using DietMealApp.Application.Functions.Day.Command.DeleteDay;
using DietMealApp.Application.Functions.Day.Query.GetDayById;
using DietMealApp.Application.Functions.Diet.Command;
using DietMealApp.Application.Functions.Day.Command.UpdateDay;
using DietMealApp.Application.Functions.Shopping.Query;
using DietMealApp.Service.Functions.Command;
using DietMealApp.Core.Entities;

namespace DietMealApp.WebClient.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoriesServices(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IMealRepository, MealRepository>();
            services.AddTransient<IDayRepository, DayRepository>();
            services.AddTransient<IDietRepository, DietRepository>();
            services.AddTransient<IShoppingListRepository, ShoppingListRepository>();
            return services;
        }

        public static IServiceCollection AddHandlersServices(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetAllProductsQuery, List<ProductDTO>>, GetAllProductsQueryHandler>();
            services.AddScoped<IRequestHandler<GetDietsByUserQuery, List<DietDTO>>, GetDietsByUserQueryHandler>();
            services.AddScoped<IRequestHandler<GetProductByIdQuery, ProductDTO>, GetProductByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetDaysByUserQuery, List<DayDTO>>, GetDaysByUserQueryHandler>();
            services.AddScoped<IRequestHandler<InsertProductCommand, Unit>, InsertProductCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteProductCommand, Unit>, DeleteProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, Unit>, UpdateProductCommandHandler>();
            services.AddScoped<IRequestHandler<GetMealsByUserQuery, List<MealDTO>>, GetMealsByUserQueryHandler>();
            services.AddScoped<IRequestHandler<InsertMealCommand, Unit>, InsertMealCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateMealCommand, Unit>, UpdateMealCommandHandler>();
            services.AddScoped<IRequestHandler<GetMealFormByIdQuery, MealFormDTO>, GetMealFormByIdQueryHandler>();
            services.AddScoped<IRequestHandler<DeleteMealCommand, Unit>, DeleteMealCommandHandler>();
            services.AddScoped<IRequestHandler<GetMealsByTypeQuery, SelectList>, GetMealsByTypeQueryHandler>();
            services.AddScoped<IRequestHandler<GetMealsBySearchQuery, SelectList>, GetMealsBySearchQueryHandler>();
            services.AddScoped<IRequestHandler<GetProductsBySearchQuery, SelectList>, GetProductsBySearchQueryHandler>();
            services.AddScoped<IRequestHandler<InsertDayCommand, Unit>, InsertDayCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteDayCommand, Unit>, DeleteDayCommandHandler>();
            services.AddScoped<IRequestHandler<GetDayFormDTOByIdQuery, DayFormDTO>, GetDayFormDTOByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetDayByIdQuery, Day>, GetDayByIdQueryHandler>();
            services.AddScoped<IRequestHandler<InsertDietCommand, Unit>, InsertDietCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateDayCommand, Unit>, UpdateDayCommandHandler>();
            services.AddScoped<IRequestHandler<GetShoppingListQuery, List<ProductsToBuyDTO>>, GetShoppingListQueryHandler>();
            services.AddScoped<IRequestHandler<GetDaysByIdsQuery, List<DayDTO>>, GetDaysByIdsQueryHandler>();
            services.AddScoped<IRequestHandler<GetMenuFormQuery, List<MenuDTO>>, GetMenuFormQueryHandler>();
            services.AddScoped<IRequestHandler<GetMenuForWeekQuery, List<MenuWeeklyViewModel>>, GetMenuForWeekQueryHandler>();
            services.AddScoped<IRequestHandler<GetShoppingListByIdQuery, ShoppingListDTO>, GetShoppingListByIdQueryHandler>();
            services.AddScoped<IRequestHandler<GetShoppingListsQuery, List<ShoppingListDTO>>, GetShoppingListsQueryHandler>();
            services.AddScoped<IRequestHandler<GetShoppingListBySearchQuery, List<ShoppingListDTO>>, GetShoppingListBySearchQueryHandler>();
            services.AddScoped<IRequestHandler<DeleteShoppingListCommand, Unit>, DeleteShoppingListCommandHandler>();
            services.AddScoped<IRequestHandler<InsertShoppingListCommand, Guid>, InsertShoppingListCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateShoppingListCommand, Unit>, UpdateShoppingListCommandHandler>();
            return services;
        }
    }
}
