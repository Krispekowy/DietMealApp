using DietMealApp.Core.DTO.Days;
using DietMealApp.Core.DTO.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.ViewModels
{
    public class MenuWeeklyViewModel
    {
        public List<MenuDTO> Days { get; set; }
        public List<MenuDay> MenuDays { get; set; }
    }
}
