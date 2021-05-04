using DietMealApp.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Service
{
    public interface IProductService
    {
        Task<List<ProductDTO>> Index();
        Task<ProductDTO> Edit(ProductDTO dto);
        Task<ProductDTO> Edit(int id);
        Task<ProductDTO> Delete(int id);
        Task Delete(ProductDTO dto);
        Task<ProductDTO> Create();
        Task<ProductDTO> Create(ProductDTO dto);

    }
}
