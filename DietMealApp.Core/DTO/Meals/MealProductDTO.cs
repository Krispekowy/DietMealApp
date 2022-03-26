using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.Meals
{
    public class MealProductDTO
    {
        public static MealProductDTO CreateFromEntity(MealProduct entity)
        {
            return new MealProductDTO()
            {
                Meal = MealDTO.CreateFromEntity(entity.Meal),
                MealId = entity.MealId,
                Product = ProductDTO.CreateFromEntity(entity.Product),
                ProductId = entity.ProductId,
                Quantity = entity.Quantity
            };
        }
        public int Quantity { get; set; }
        public Guid MealId { get; set; }
        public MealDTO Meal { get; set; }
        public Guid ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
