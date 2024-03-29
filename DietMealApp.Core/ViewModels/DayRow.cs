﻿using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.ViewModels
{
    public sealed class DayRow
    {
        public ICollection<DayDTO> Days { get; set; }
        public int Index { get; set; }
    }
}
