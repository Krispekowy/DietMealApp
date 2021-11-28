using DietMealApp.Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Diet.Command
{
    public sealed class InsertDietCommand : IRequest<Unit>
    {
        public DietDTO DietDTO { get; set; }
    }
}
