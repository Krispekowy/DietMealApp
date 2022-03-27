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
                    NumberOfMeals = entity.NumberOfMeals,
                    DayMeals = entity.DayMeals.Select(a=> DayMealsDTO.CreateFromEntity(a)).ToList()
                };
                return dto;
            }
            return null;
        }
        public static DayDTO CreateFromOtherDto(DayFormDTO dto)
        {
            if (dto != null)
            {
                var dayDto = new DayDTO()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    //DietDays = dto.DietDays,
                    Kcal = dto.Kcal,
                    Carbohydrates = dto.Carbohydrates,
                    Protein = dto.Protein,
                    Fats = dto.Fats,
                    NumberOfMeals = dto.MealsCount,
                    DayMeals = dto.Meals.Where(a=>dto.MealItems.Select(b=>b.SelectedMeal).ToList().Contains(a.Id)).Select(c=> new DayMealsDTO() { DayId = dto.Id, MealId = c.Id, Type = c.TypeOfMeal, Meal = c}).ToList()
                };
                return dayDto;
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
