using DietMealApp.Core.Abstract;
using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DietMealApp.Core.DTO.Days
{
    public sealed class DayDTO : _BaseDTO
    {
        public DayDTO() : base() { }
        public static DayDTO CreateFromEntity(Day entity)
        {
            if (entity != null)
            {
                var dto = new DayDTO()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    DietDays = entity.DietDays,
                    Kcal = entity.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Kcal / a.Product.QuantityUnit) * a.Quantity), 2)),
                    Carbohydrates = entity.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Carbohydrates / a.Product.QuantityUnit) * a.Quantity), 2)),
                    Protein = entity.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Protein / a.Product.QuantityUnit) * a.Quantity), 2)),
                    Fats = entity.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Fats / a.Product.QuantityUnit) * a.Quantity), 2)),
                    NumberOfMeals = entity.NumberOfMeals
                };
                return dto;
            }
            return null;
        }

        public string Name { get; set; }
        public decimal Kcal { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }
        public ICollection<DayMealsDTO> DayMeals { get; set; }
        public ICollection<DietDay> DietDays { get; set; }
        public int NumberOfMeals { get; set; }
    }
}
