using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.DTO.Products
{
    public class IndexProductDTO
    {
        public static List<ProductDTO> ProductEntityToDTO(List<Product> entities)
        {
            if (entities != null)
            {
                List<ProductDTO> productsDTO = new List<ProductDTO>();
                productsDTO = entities.Select(x => new ProductDTO()
                {
                    Id = x.Id,
                    Category = x.Category,
                    Kcal = x.Kcal,
                    ProductName = x.ProductName,
                    Photo150x150Path = x.Photo150x150Path,
                    PhotoFullPath = x.PhotoFullPath,
                    Carbohydrates = x.Carbohydrates,
                    Fats = x.Fats,
                    Protein = x.Protein,
                    Unit = x.Unit,
                    QuantityUnit = x.QuantityUnit
                }).ToList();
                return productsDTO;
            }
            return null;
        }
        public List<ProductDTO> Products { get; set; }
    }
}
