using DietMealApp.Core.Abstract;
using DietMealApp.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.Products
{
    public class ProductFormDTO : _BaseDTO
    {
        [Required(ErrorMessage = "Nazwa produktu jest wymagana")]
        [MinLength(3, ErrorMessage = "Nazwa produktu nie może być krótsza niż 3 znaki")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Podaj ilość kalorii")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "W tym polu możesz wpisać tylko cyfry")]
        public int Kcal { get; set; }
        [Required(ErrorMessage = "Podaj ilość jednostek")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "W tym polu możesz wpisać tylko cyfry")]
        public int QuantityUnit { get; set; }
        [Required(ErrorMessage = "Wybierz jednostkę miary produktu")]
        public Unit Unit { get; set; }
        public ProductCategories Category { get; set; }
        public IFormFile Photo { get; set; }
        public string PhotoPath { get; set; }
    }
}
