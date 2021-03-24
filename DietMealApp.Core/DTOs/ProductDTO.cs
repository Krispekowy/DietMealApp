using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DietMealApp.Service.DTOs
{
    public sealed class ProductDTO : _BaseDTO
    {
        public ProductDTO() : base() { }
        public static ProductDTO ProductEntityToDTO(Product entity)
        {
            if (entity != null)
            {
                var dto = new ProductDTO()
                {
                    Id = entity.Id,
                    Category = entity.Category,
                    Kcal = entity.Kcal,
                    ProductName = entity.ProductName,
                    PhotoPath = entity.PhotoPath,
                    Unit = entity.Unit,
                    QuantityUnit = entity.QuantityUnit
                };
                return dto;
            }
            return null;
        }

        [Required(ErrorMessage = "Nazwa produktu jest wymagana")]
        [MinLength(3, ErrorMessage= "Nazwa produktu nie może być krótsza niż 3 znaki")]
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
