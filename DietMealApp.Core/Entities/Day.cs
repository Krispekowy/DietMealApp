using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DietMealApp.Core.Entities
{
    public class Day : _BaseEntity
    {
        public static Day CreateFromDto(DayDTO dto)
        {
            return new Day()
            {
                CanBeEdited = true,
                DayMeals = dto.DayMeals.Select(a => new DayMeals() { DayId = a.DayId, MealId = a.MealId }).ToList(),
                Name = dto.Name,
                NumberOfMeals = dto.NumberOfMeals,
                Id = dto.Id
            };
        }
        public static Day CreateFromDto(DayFormDTO dto)
        {
            return new Day()
            {
                CanBeEdited = true,
                DayMeals = dto.MealItems.Select(a => new DayMeals()
                {
                    DayId = dto.Id,
                    //Meal = Meal.CreateFromDto(dto.Meals.Where(b => b.Id == a.SelectedMeal).FirstOrDefault()),
                    MealId = a.SelectedMeal,
                    Type = a.AssignedMealTimeType
                }).ToList(),
                Name = dto.Name,
                NumberOfMeals = dto.MealsCount,
                Id = dto.Id
            };
        }
        public string Name { get; set; }
        public virtual List<DietDay> DietDays { get; set; }
        public virtual List<DayMeals> DayMeals { get; set; }
        public virtual List<ShoppingListDays> ShoppingListDays { get; set; }
        public int NumberOfMeals { get; set; }
        public string UserId { get; set; }
    }
}
