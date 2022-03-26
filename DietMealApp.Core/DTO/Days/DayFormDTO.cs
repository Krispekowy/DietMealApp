using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.Days
{
    public sealed class DayFormDTO
    {
        public static DayFormDTO CreateFromEntity(Day entity)
        {
            if (entity != null)
            {
                var dto = new DayFormDTO()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    MealsCount = entity.NumberOfMeals,
                    MealItems = entity.DayMeals.Select(a => new MealMenuItemDTO() { AssignedMealTimeType = a.Type, SelectedMeal = a.MealId }).ToList(),
                    UserId = entity.UserId
                };
                return dto;
            }
            return null;
        }
        public Guid Id { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = "Pole nazwa dnia jest wymagane")]
        [DisplayName("Nazwa dnia")]
        [MinLength(3, ErrorMessage = "Nazwa musi mieć co najmniej 3 znaki")]
        [MaxLength(50, ErrorMessage = "Nazwa może mieć maksymalnie 50 znaków")]
        public string Name { get; set; }
        public List<MealDTO> Meals { get; set; }
        public List<MealMenuItemDTO> MealItems { get; set; }
        public int MealsCount { get; set; }
    }
}
