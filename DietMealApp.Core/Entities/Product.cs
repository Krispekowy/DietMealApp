using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DietMealApp.Core.Entities
{
    public class Product : _BaseEntity
    {
        public static Product GetProductFromDTO(ProductDTO dto)
        {
            return new Product()
            {
                Id = dto.Id,
                Category = dto.Category,
                Kcal = dto.Kcal,
                PhotoPath = dto.PhotoPath,
                ProductName = dto.ProductName,
                QuantityUnit = dto.QuantityUnit,
                Unit = dto.Unit
            };
        }
        public string ProductName { get; set; }
        public int Kcal { get; set; }
        public int QuantityUnit { get; set; }
        public Unit Unit { get; set; }
        public ProductCategories Category { get; set; }
        public virtual List<MealProduct> MealProducts { get; set; }
        public string PhotoPath { get; set; }
    }
}
