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
        public static MealDTO CreateFromEntity(Meal entity)
        {
            return new MealDTO()
            {
                Id = entity.Id,
                MealName = entity.MealName,
                MealProducts = entity.MealProducts.Select(a=> MealProductDTO.CreateFromEntity(a)).ToList(),
                Description = entity.Description,
                NumberOfServings = entity.NumberOfServings,
                Photo150x150Path = entity.Photo150x150Path,
                PhotoFullPath = entity.PhotoFullPath,
                TypeOfMeal = entity.TypeOfMeal,
                Fats = Math.Round(entity.MealProducts.Sum(a => (a.Product.Fats / a.Product.QuantityUnit) * a.Quantity) / entity.NumberOfServings, 2),
                Kcal = Math.Round(entity.MealProducts.Sum(a => (a.Product.Kcal / a.Product.QuantityUnit) * a.Quantity) / entity.NumberOfServings, 2),
                Protein = Math.Round(entity.MealProducts.Sum(a => (a.Product.Protein / a.Product.QuantityUnit) * a.Quantity) / entity.NumberOfServings, 2),
                Carbohydrates = Math.Round(entity.MealProducts.Sum(a => (a.Product.Carbohydrates / a.Product.QuantityUnit) * a.Quantity) / entity.NumberOfServings, 2)
            };
        }
        public MealDTO() : base() { }

        [Required(ErrorMessage = "Pole typ posiłku jest wymagane")]
        public MealTimeType TypeOfMeal { get; set; }
        [Required(ErrorMessage = "Pole nazwa posiłku jest wymagane")]
        [MinLength(5, ErrorMessage = "Nazwa posiłku musi składać się z minimum 5 znaków")]
        [MaxLength(50, ErrorMessage = "Nazwa posiłku może składać się z maksimum 50 znaków")]
        public string MealName { get; set; }
        [MaxLength(1000, ErrorMessage = "Maksymalna długość opisu to 1000 znaków")]
        public string Description { get; set; }
        public decimal Kcal { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }
        public int NumberOfServings { get; set; }
        public string Photo150x150Path { get; set; }
        public string PhotoFullPath { get; set; }
        public List<MealProductDTO> MealProducts { get; set; }
    }
}
