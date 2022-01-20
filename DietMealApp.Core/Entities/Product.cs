using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                PhotoFullPath = dto.PhotoFullPath,
                Photo150x150Path = dto.Photo150x150Path,
                ProductName = dto.ProductName,
                QuantityUnit = dto.QuantityUnit,
                Unit = dto.Unit
            };
        }
        public string ProductName { get; set; }
        public decimal Kcal { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }
        public int QuantityUnit { get; set; }
        public Unit Unit { get; set; }
        public ProductCategories Category { get; set; }
        [ForeignKey("ProductId")]
        public virtual List<MealProduct> MealProducts { get; set; }
        public string PhotoFullPath { get; set; }
        public string Photo150x150Path { get; set; }
    }
}
