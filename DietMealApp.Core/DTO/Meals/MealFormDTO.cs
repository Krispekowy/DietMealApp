using DietMealApp.Core.Abstract;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using DietMealApp.Core.Extensions;
using DietMealApp.Core.Intersections;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.Meals
{
    public class MealFormDTO : _BaseDTO
    {
        public static MealFormDTO CreateFromEntity(Meal entity)
        {
            return new MealFormDTO()
            {
                Id = entity.Id,
                Description = entity.Description,
                MealName = entity.MealName,
                NumberOfServings = entity.NumberOfServings,
                Photo150x150Path = entity.Photo150x150Path,
                PhotoFullPath = entity.PhotoFullPath,
                TypeOfMeal = entity.TypeOfMeal,
                UserId = entity.UserId,
                MealProducts = entity.MealProducts.Select(a=> MealProductDTO.CreateFromEntity(a)).ToList(),
                Fats = Math.Round(entity.MealProducts.Sum(a => (a.Product.Fats / a.Product.QuantityUnit) * a.Quantity) / entity.NumberOfServings, 2),
                Kcal = Math.Round(entity.MealProducts.Sum(a => (a.Product.Kcal / a.Product.QuantityUnit) * a.Quantity) / entity.NumberOfServings, 2),
                Protein = Math.Round(entity.MealProducts.Sum(a => (a.Product.Protein / a.Product.QuantityUnit) * a.Quantity) / entity.NumberOfServings, 2),
                Carbohydrates = Math.Round(entity.MealProducts.Sum(a => (a.Product.Carbohydrates / a.Product.QuantityUnit) * a.Quantity) / entity.NumberOfServings, 2)
            };
        }
        [Required(ErrorMessage = "Pole typ posiłku jest wymagane")]
        public MealTimeType TypeOfMeal { get; set; }
        [Required(ErrorMessage = "Pole nazwa posiłku jest wymagane")]
        [MinLength(5, ErrorMessage = "Nazwa posiłku musi składać się z minimum 5 znaków")]
        [MaxLength(50, ErrorMessage = "Nazwa posiłku może składać się z maksimum 50 znaków")]
        public string MealName { get; set; }
        [MaxLength(10000, ErrorMessage = "Maksymalna długość przepisu to 10000 znaków")]
        public string Description { get; set; }
        public decimal Kcal { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }
        public int NumberOfServings { get; set; }
        public string PhotoFullPath { get; set; }
        public string Photo150x150Path { get; set; }
        public List<ProductDTO> Products { get; set; }
        public List<MealProductDTO> MealProducts { get; set; }
        [MaxWidthHeight(3000, 3000)]
        [MinWidthHeight(500, 500)]
        [IsSquare]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile Photo { get; set; }
    }
}
