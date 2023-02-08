using DietMealApp.Core.DTO.Menu;
using DietMealApp.Core.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Menu.Query.GetMenuForWeek
{
    public class GetMenuForWeekQuery : IRequest<List<MenuDay>>
    {
        public List<MenuDTO> MenuDto { get; set; }
        public string userId { get; set; }
    }
}
