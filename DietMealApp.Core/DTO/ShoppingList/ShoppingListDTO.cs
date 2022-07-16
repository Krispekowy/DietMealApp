using DietMealApp.Core.Abstract;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.DTO.ShoppingList;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using DietMealApp.Core.Intersections;
using DietMealApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietMealApp.Core.DTO.ShoppingList
{
    public sealed class ShoppingListDTO : _BaseDTO
    {
        public static ShoppingListDTO CreateFromEntity(Entities.ShoppingList entity)
        {
            return new ShoppingListDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                CreationDate = entity.CreationDate,
                Products = entity.ShoppingListProducts.Select(a => new ShoppingListProductsDTO()
                {
                    Product = ProductDTO.CreateFromEntity(a.Product),
                    ProductId = a.ProductId,
                    Quantity = a.Quantity,
                    ShoppingListId = a.ShoppingListId
                }).ToList(),
                UserId = entity.UserId,
                Meals = entity.ShoppingListMeals.Select(a=> new ShoppingListMealsDTO()
                {
                    MealId = a.MealId,
                    Quantity = (int)a.Quantity,
                    ShoppingListId= a.ShoppingListId
                }).ToList(),
                Days = entity.ShoppingListDays.Select(a=> new ShoppingListDaysDTO()
                {
                    DayId = a.DayId,
                    Quantity = a.Quantity,
                    ShoppingListId = a.ShoppingListId
                }).ToList()
            };
        }
        public static ShoppingListDTO CreateFromViewModel(CreateShoppingListViewModel vm)
        {
            return new ShoppingListDTO()
            {
                Id = Guid.NewGuid(),
                Name = "ShoppingList_" + DateTime.Now.ToString(),
                UserId = vm.UserId,
                Products = vm.Products?.Select(a => new ShoppingListProductsDTO()
                {
                    ProductId = a.ProductId,
                    Quantity = a.Quantity,
                    ShoppingListId = a.ShoppingListId,
                }).ToList(),
                Days = vm.Days?.Select(a=> new ShoppingListDaysDTO()
                {
                    DayId = a.DayId,
                    Quantity = a.Quantity
                }).ToList(),
                Meals = vm.Meals?.Select(a => new ShoppingListMealsDTO()
                {
                    MealId = a.MealId,
                    Quantity = a.Quantity
                }).ToList(),
            };
        }

        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ShoppingListProductsDTO> Products { get; set; }
        public List<ShoppingListMealsDTO> Meals { get; set; }
        public List<ShoppingListDaysDTO> Days { get; set; }
    }
}
