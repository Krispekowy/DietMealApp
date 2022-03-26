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
                    //DayMeals = DayMealsDTO.CreateFromEntity(entity.DayMeals),
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

        public static List<DayDTO> CreateFromEntity(List<Day> entity)
        {
            if (entity != null)
            {
                var listDto = new List<DayDTO>();
                foreach (var day in entity)
                {
                    var dto = new DayDTO()
                    {
                        Id = day.Id,
                        Name = day.Name,
                        DayMeals = day.DayMeals.Select(a => new DayMealsDTO() { Type = a.Type, MealId = a.MealId, DayId = a.DayId, Meal = MealDTO.CreateFromEntity(a.Meal) }).ToList(),
                        DietDays = day.DietDays,
                        Kcal = day.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Kcal / a.Product.QuantityUnit) * a.Quantity), 2)),
                        Carbohydrates = day.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Carbohydrates / a.Product.QuantityUnit) * a.Quantity), 2)),
                        Protein = day.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Protein / a.Product.QuantityUnit) * a.Quantity), 2)),
                        Fats = day.DayMeals.Sum(a => Math.Round(a.Meal.MealProducts.Sum(a => (a.Product.Fats / a.Product.QuantityUnit) * a.Quantity), 2)),
                        NumberOfMeals = day.NumberOfMeals
                    };
                    listDto.Add(dto);
                }
                
                return listDto;
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
