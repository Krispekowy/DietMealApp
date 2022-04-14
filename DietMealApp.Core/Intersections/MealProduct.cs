using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DietMealApp.Core.Intersections
{
    public class MealProduct
    {
        public static MealProduct CreateFromDto(MealProductDTO dto)
        {
            return new MealProduct()
            {
                MealId = dto.MealId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                //Product = Product.CreateFromDto(dto.Product)
            };
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Guid MealId { get; set; }
        public Meal Meal { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
