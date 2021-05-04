using DietMealApp.Core.DTO;
using DietMealApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietMealApp.Service.Services;
using System.IO;
using Microsoft.AspNetCore.Http;
using DietMealApp.Core.Entities;

namespace DietMealApp.Service
{
    public class ProductService : _BaseService, IProductService
    {
        private readonly IProductRepository _productRepoistory;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IProductRepository _productRepository;

        public ProductService(
            IProductRepository productRepoistory,
            IHostingEnvironment hostingEnvironment,
            IProductRepository productRepository
            )
        {
            _productRepoistory = productRepoistory;
            _hostingEnvironment = hostingEnvironment;
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> Create()
        {
            return new ProductDTO();
        }

        public async Task<ProductDTO> Create(ProductDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = ModelState
                    .Select(a => a.Value.Errors)
                    .Where(b => b.Count > 0)
                    .ToList();
                return null;
            }
            string uniqueFileName = null;
            if (dto.Photo != null)
            {
                uniqueFileName = UploadPhoto(dto.Photo);
            }
            var product = Product.GetProductFromDTO(dto);
            product.PhotoPath = uniqueFileName;
            _productRepository.Insert(product);
            await _productRepoistory.CommitAsync();
            return dto;
        }

        public Task<ProductDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ProductDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> Edit(ProductDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> Edit(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDTO>> Index()
        {
            try
            {
                var products = _productRepoistory.Get();
                var productsDTO = new List<ProductDTO>();
                foreach (var product in products)
                {
                    var productDTO = ProductDTO.ProductEntityToDTO(product);
                    productsDTO.Add(productDTO);
                }
                return productsDTO;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProductDTO>();
            }
        }

        private string UploadPhoto(IFormFile photo)
        {
            string uniqueFileName;
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            photo.CopyTo(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }
    }
}
