using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Day.Query.GetDayById
{
    public sealed class GetDayByIdQuery : IRequest<Core.Entities.Day>
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
    }
}
