using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.Enums;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.Days
{
    public  class DayMealsDTO
    {
        public static DayMealsDTO CreateFromEntity(DayMeals entity)
        {
            return new DayMealsDTO()
            {
                Day = DayDTO.CreateFromEntity(entity.Day),
                DayId = entity.DayId,
                Meal = MealDTO.CreateFromEntity(entity.Meal),
                MealId = entity.MealId,
                Type = entity.Type
            };
        }

        public Guid DayId { get; set; }
        public DayDTO Day { get; set; }
        public Guid MealId { get; set; }
        public MealDTO Meal { get; set; }
        public MealTimeType Type { get; set; }
    }
}
