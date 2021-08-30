using DietMealApp.Core.Abstract;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DietMealApp.Core.DTO.Meals
{
    public class MealDTO : _BaseDTO
    {
        public MealDTO() : base() { }

        [Required(ErrorMessage = "Pole typ posiłku jest wymagane")]
        public MealTimeType TypeOfMeal { get; set; }
        [Required(ErrorMessage = "Pole nazwa posiłku jest wymagane")]
        [MinLength(5, ErrorMessage = "Nazwa posiłku musi składać się z minimum 5 znaków")]
        [MaxLength(50, ErrorMessage = "Nazwa posiłku może składać się z maksimum 50 znaków")]
        public string MealName { get; set; }
        [MaxLength(1000, ErrorMessage = "Maksymalna długość opisu to 1000 znaków")]
        public string Description { get; set; }
        public int Kcal { get; set; } = 0;
        public List<MealProduct> MealProducts { get; set; }

    }
}
