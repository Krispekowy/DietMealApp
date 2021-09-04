using DietMealApp.Core.DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.ViewModels
{
    public sealed class ProductRow
    {
        public ICollection<ProductDTO> Products { get; set; }
        public int Index { get; set; }
    }
}
