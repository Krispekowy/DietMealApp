using AutoMapper;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Meal.Query.GetMealById
{
    public class GetMealFormByIdQueryHandler : IRequestHandler<GetMealFormByIdQuery, MealFormDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMealRepository _mealRepository;
        private readonly IProductRepository _productRepository;

        public GetMealFormByIdQueryHandler(
            IMapper mapper,
            IMealRepository mealRepository,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _mealRepository = mealRepository;
            _productRepository = productRepository;
        }
        public async Task<MealFormDTO> Handle(GetMealFormByIdQuery request, CancellationToken cancellationToken)
        {
            var meal = await _mealRepository.GetByID(request.Id);
            var products = await _productRepository.Get().ToListAsync();
            var productDTO = _mapper.Map<List<ProductDTO>>(products);
            var result = new MealFormDTO()
            {
                Id = meal.Id,
                Description = meal.Description,
                Carbohydrates = meal.Carbohydrates,
                Protein = meal.Protein,
                Fats = meal.Fats,
                Kcal = meal.Kcal,
                MealName = meal.MealName,
                Products = productDTO,
                TypeOfMeal = meal.TypeOfMeal,
                UserId = meal.UserId,
                MealProducts = meal.MealProducts
            };
            return _mapper.Map<MealFormDTO>(result);
        }
    }
}
