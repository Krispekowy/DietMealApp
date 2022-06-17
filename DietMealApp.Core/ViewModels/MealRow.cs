using DietMealApp.Core.DTO.Meals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.ViewModels
{
    public sealed class MealRow
    {
        public ICollection<MealDTO> Meals { get; set; }
        public int Index { get; set; }
    }
}
