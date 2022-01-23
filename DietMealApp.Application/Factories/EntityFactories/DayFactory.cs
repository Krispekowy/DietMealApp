using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Factories.EntityFactories
{
    public static class DayFactory
    {
        public static Day CreateDayFromFormDto(DayFormDTO dto)
        {
            return new Day()
            {
                CanBeEdited = true,
                Carbohydrates = dto.Carbohydrates,
                DayMeals = dto.MealItems.Select(a => new Core.Intersections.DayMeals() { MealId = a.SelectedMeal, Type = a.AssignedMealTimeType }).ToList(),
                Fats = dto.Fats,
                Id = dto.Id,
                Kcal = dto.Kcal,
                Name = dto.Name,
                Protein = dto.Protein,
                UserId = dto.UserId,
                NumberOfMeals = dto.MealsCount,
                ModifyDate = System.DateTime.Now
            };
        }
    }
}
