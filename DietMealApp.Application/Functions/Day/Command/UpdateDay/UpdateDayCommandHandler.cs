using AutoMapper;
using DietMealApp.Application.Factories.EntityFactories;
using DietMealApp.Application.Functions.Meal.Query.GetMealById;
using DietMealApp.Core.Interfaces;
using DietMealApp.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Application.Commons.Abstract;

namespace DietMealApp.Application.Functions.Day.Command.UpdateDay
{
    public class UpdateDayCommandHandler : BaseRequestHandler<UpdateDayCommand, Unit>
    {
        private readonly IDayRepository _dayRepository;

        public UpdateDayCommandHandler(
            IDayRepository dayRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _dayRepository = dayRepository;
        }

        public override async Task<Unit> Handle(UpdateDayCommand request, CancellationToken cancellationToken)
        {
            var entity = DayFactory.CreateDayFromFormDto(request.DayForm);
            _dayRepository.Update(entity);
            await _dayRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
