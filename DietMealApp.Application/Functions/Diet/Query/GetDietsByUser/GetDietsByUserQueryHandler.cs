using AutoMapper;
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
    public class GetDietsByUserQueryHandler : IRequestHandler<GetDietsByUserQuery, List<DietDTO>>
    {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public GetDietsByUserQueryHandler(
            IDietRepository dietRepository,
            IMapper mapper)
        {
            _dietRepository = dietRepository;
            _mapper = mapper;
        }

        public Task<List<DietDTO>> Handle(GetDietsByUserQuery request, CancellationToken cancellationToken)
        {
            var diets = _dietRepository.Get(a=>a.UserId == Guid.Parse(request.UserId)).ToList();
            var dto = _mapper.Map<List<DietDTO>>(diets);
            return Task.FromResult(dto);
        }
    }
}
