using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DietMealApp.Service.DTOs
{
    public sealed class MealDTO : _BaseDTO
    {
        public MealDTO() : base() { }
        public static MealDTO MealEntityToDTO(Meal entity)
        {
            if (entity != null)
            {
                var dto = new MealDTO()
                {
                    Id = entity.Id,
                    MealName = entity.MealName,
                    Kcal = entity.Kcal,
                    Description = entity.Description,
                    TypeOfMeal = entity.TypeOfMeal,
                    MealProducts = entity.MealProducts
                };
                return dto;
            }
            return null;
        }

        [Required(ErrorMessage = "Pole typ posiłku jest wymagane")]
        public TypesOfMeal TypeOfMeal { get; set; }
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
