using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Factories.DtoFactories
{
    public static class DayDtoFactory
    {
        public static DayDTO CreateFromEntity(Day entity)
        {
            return new DayDTO
            {
                Carbohydrates = entity.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Carbohydrates / a.Product.QuantityUnit) * a.Quantity), 2)),
                Fats = entity.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Fats / a.Product.QuantityUnit) * a.Quantity), 2)),
                Kcal = entity.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Kcal / a.Product.QuantityUnit) * a.Quantity), 2)),
                Protein = entity.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Protein / a.Product.QuantityUnit) * a.Quantity), 2)),
                Id = entity.Id,
                Name = entity.Name,
                DayMeals = entity.DayMeals.Select(a => new DayMealsDTO() { DayId = a.DayId, MealId = a.MealId, Type = a.Type }).ToList()
            };
        }
    }
}
