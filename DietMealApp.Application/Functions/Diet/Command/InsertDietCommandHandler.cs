﻿using AutoMapper;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Diet.Command
{
    public class InsertDietCommandHandler : IRequestHandler<InsertDietCommand, MediatR.Unit>
    {
        private readonly IDietRepository _dietRepository;

        public InsertDietCommandHandler(IDietRepository dietRepository)
        {
            _dietRepository = dietRepository;
        }
        public async Task<MediatR.Unit> Handle(InsertDietCommand request, CancellationToken cancellationToken)
        {
            var entity = DietMealApp.Core.Entities.Diet.DietDTOToEntity(request.DietDTO);
            _dietRepository.Insert(entity);
            await _dietRepository.CommitAsync();
            return MediatR.Unit.Value;
        }
    }
    }
