using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DietMealApp.Core.Entities
{
    public class Meal : _BaseEntity
    {
        public static Meal CreateFromDto(MealDTO dto)
        {
            return new Meal()
            {
                Id = dto.Id,
                Description = dto.Description,
                NumberOfServings = dto.NumberOfServings,
                Photo150x150Path = dto.Photo150x150Path,
                PhotoFullPath = dto.PhotoFullPath,
                TypeOfMeal = dto.TypeOfMeal,
                UserId = dto.UserId,
                MealName = dto.MealName,
                MealProducts = dto.MealProducts
                .Select(a => new MealProduct()
                {
                    MealId = a.MealId,
                    ProductId = a.ProductId,
                    Product = Product.CreateFromDto(a.Product),
                    Quantity = a.Quantity
                })
                .ToList(),

            };
        }
        public static Meal CreateFromDto(MealFormDTO dto)
        {
            return new Meal()
            {
                Id = dto.Id,
                Description = dto.Description,
                NumberOfServings = dto.NumberOfServings,
                Photo150x150Path = dto.Photo150x150Path,
                PhotoFullPath = dto.PhotoFullPath,
                TypeOfMeal = dto.TypeOfMeal,
                UserId = dto.UserId,
                MealName = dto.MealName,
                MealProducts = dto.MealProducts?.Select(a => MealProduct.CreateFromDto(a)).ToList()
            };
        }
        public MealTimeType TypeOfMeal { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int NumberOfServings { get; set; }
        public string Photo150x150Path { get; set; }
        public string PhotoFullPath { get; set; }
        [ForeignKey("MealId")]
        public virtual List<MealProduct> MealProducts { get; set; } = new List<MealProduct>();
        public virtual List<DayMeals> DayMeals { get; set; }
    }
}
