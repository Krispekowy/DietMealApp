﻿using DietMealApp.Core.DTO.Days;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Command.InsertDay
{
    public class InsertDayCommand : IRequest<Unit>
    {
        public DayFormDTO DayForm { get; set; }
    }
}
