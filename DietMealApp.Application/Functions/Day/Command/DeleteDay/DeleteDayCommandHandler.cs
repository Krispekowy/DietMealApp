using AutoMapper;
using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Application.Functions.Day.Query.GetDayById;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Command.DeleteDay
{
    public class DeleteDayCommandHandler : BaseRequestHandler<DeleteDayCommand, Unit>
    {
        private readonly IDayRepository _dayRepository;

        public DeleteDayCommandHandler(
            IDayRepository dayRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _dayRepository = dayRepository;
        }

        public override async Task<Unit> Handle(DeleteDayCommand request, CancellationToken cancellationToken)
        {
            var day = await _mediator.Send(new GetDayByIdQuery { Id = request.DayId });
            if (day == null)
            {
                throw new NullReferenceException($"Day with Id: { request.DayId} doesn't exists");
            }
            await _dayRepository.Delete(request.DayId);
            await _dayRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
