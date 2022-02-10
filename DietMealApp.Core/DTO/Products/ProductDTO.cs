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
        [Required(ErrorMessage = "Wybierz plik")]
        [MaxWidthHeight(3000, 3000)]
        [MinWidthHeight(500, 500)]
        [IsSquare]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile Photo { get; set; }
        public string PhotoFullPath { get; set; }
        public string Photo150x150Path { get; set; }
    }
}
