
using DietMealApp.Core.DTO.Menu;
using MediatR;
using System;
using System.Collections.Generic;

namespace DietMealApp.Application.Functions.Menu.Query.GetMenuForm
{
    public class GetMenuFormQuery : IRequest<List<MenuDTO>>
    {
        public string UserId { get; set; }
    }
}
