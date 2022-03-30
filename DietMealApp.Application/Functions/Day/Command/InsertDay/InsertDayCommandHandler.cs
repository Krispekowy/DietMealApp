﻿using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Command.InsertDay
{
    public class InsertDayCommandHandler : BaseRequestHandler<InsertDayCommand, Unit>
    {
        private readonly IDayRepository _dayRepository;

        public InsertDayCommandHandler(
            IDayRepository dayRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _dayRepository = dayRepository;
        }
        public override async Task<Unit> Handle(InsertDayCommand request, CancellationToken cancellationToken)
        {
            var entity = Core.Entities.Day.CreateFromDto(request.DayForm);
            _dayRepository.Insert(entity);
            await _dayRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
