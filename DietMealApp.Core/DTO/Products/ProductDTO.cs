using DietMealApp.Core.Abstract;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using DietMealApp.Core.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DietMealApp.Core.DTO.Products
{
    public class ProductDTO : _BaseDTO
    {
        public static ProductDTO CreateFromEntity(Product entity)
        {
            return new ProductDTO()
            {
                Carbohydrates = entity.Carbohydrates,
                Category = entity.Category,
                Fats = entity.Fats,
                Id = entity.Id,
                Kcal = entity.Kcal,
                Photo150x150Path = entity.Photo150x150Path,
                PhotoFullPath = entity.PhotoFullPath,
                ProductName = entity.ProductName,
                Protein = entity.Protein,
                QuantityUnit = entity.QuantityUnit,
                Unit = entity.Unit
            };
        }
        public ProductDTO() : base() { }

        [Required(ErrorMessage = "Nazwa produktu jest wymagana")]
        [MinLength(3, ErrorMessage= "Nazwa produktu nie może być krótsza niż 3 znaki")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Podaj ilość kalorii")]
        [RegularExpression(@"^\d+\,?\d*$", ErrorMessage = "W tym polu możesz wpisać tylko cyfry")]
        public decimal Kcal { get; set; }
        [Required(ErrorMessage = "Podaj ilość jednostek")]
        [RegularExpression(@"^\d+\,?\d*$", ErrorMessage = "W tym polu możesz wpisać tylko cyfry")]
        public int QuantityUnit { get; set; } = 100;
        [Required(ErrorMessage = "Podaj ilość białka")]
        [RegularExpression(@"^\d+\,?\d*$", ErrorMessage = "W tym polu możesz wpisać tylko cyfry")]
        public decimal Protein { get; set; }
        [Required(ErrorMessage = "Podaj ilość węglowodanów")]
        [RegularExpression(@"^\d+\,?\d*$", ErrorMessage = "W tym polu możesz wpisać tylko cyfry")]
        public decimal Carbohydrates { get; set; }
        [Required(ErrorMessage = "Podaj ilość tłuszczy")]
        [RegularExpression(@"^\d+\,?\d*$", ErrorMessage = "W tym polu możesz wpisać tylko cyfry")]
        public decimal Fats { get; set; }
        [Required(ErrorMessage = "Wybierz jednostkę miary produktu")]
        public Unit Unit { get; set; }
        public ProductCategories Category { get; set; }
        [MaxWidthHeight(3000, 3000)]
        [MinWidthHeight(500, 500)]
        [IsSquare]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile Photo { get; set; }
        public string PhotoFullPath { get; set; }
        public string Photo150x150Path { get; set; }
    }
}
