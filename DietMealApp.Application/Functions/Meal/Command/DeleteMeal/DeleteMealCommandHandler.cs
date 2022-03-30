using AutoMapper;
using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Meal.Command.DeleteMeal
{
    public class DeleteMealCommandHandler : BaseRequestHandler<DeleteMealCommand,Unit>
    {
        private readonly IMealRepository _mealRepository;

        public DeleteMealCommandHandler(
            IMealRepository mealRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _mealRepository = mealRepository;
        }

        public override async Task<Unit> Handle(DeleteMealCommand request, CancellationToken cancellationToken)
        {
            await _mealRepository.Delete(request.Id);
            await _mealRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
