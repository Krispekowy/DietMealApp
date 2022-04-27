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

namespace DietMealApp.Application.Functions.Day.Query.GetDayById
{
    public class GetDayByIdQueryHandler : BaseRequestHandler<GetDayByIdQuery, Core.Entities.Day>
    {
        private readonly IDayRepository _dayRepository;

        public GetDayByIdQueryHandler(
            IDayRepository dayRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _dayRepository = dayRepository;
        }
        public override async Task<Core.Entities.Day> Handle(GetDayByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dayRepository.GetByID(request.Id);
        }
    }
}
