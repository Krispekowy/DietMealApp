using AutoMapper;
using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.DTO;
using DietMealApp.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Diet.Query.GetDietsByUser
{
    public class GetDietsByUserQueryHandler : BaseRequestHandler<GetDietsByUserQuery, List<DietDTO>>
    {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public GetDietsByUserQueryHandler(
            IDietRepository dietRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _dietRepository = dietRepository;
        }

        public override async Task<List<DietDTO>> Handle(GetDietsByUserQuery request, CancellationToken cancellationToken)
        {
            var diets = await _dietRepository.Get(a=>a.UserId == Guid.Parse(request.UserId)).ToListAsync();
            var dto = _mapper.Map<List<DietDTO>>(diets);
            return dto;
        }
    }
}
