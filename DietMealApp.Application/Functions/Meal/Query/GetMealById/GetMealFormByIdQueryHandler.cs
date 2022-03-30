using AutoMapper;
using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Meals;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Interfaces;
using DietMealApp.Service.Functions.Query;
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
    public class GetMealFormByIdQueryHandler : BaseRequestHandler<GetMealFormByIdQuery, MealFormDTO>
    {
        private readonly IMealRepository _mealRepository;

        public GetMealFormByIdQueryHandler(
            IMealRepository mealRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _mealRepository = mealRepository;
        }
        public override async Task<MealFormDTO> Handle(GetMealFormByIdQuery request, CancellationToken cancellationToken)
        {
            var meal = await _mealRepository.GetByID(request.Id);
            var products = await _mediator.Send(new GetAllProductsQuery() { OrderBy = Core.Enums.OrderByProductOptions.ByName });
            var result = MealFormDTO.CreateFromEntity(meal);
            result.Products = products;
            return result;
        }
    }
}
