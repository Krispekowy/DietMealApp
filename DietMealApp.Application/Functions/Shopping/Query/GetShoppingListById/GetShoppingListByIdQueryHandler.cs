using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.ShoppingList;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Query.GetShoppingListById
{
    public class GetShoppingListByIdQueryHandler : BaseRequestHandler<GetShoppingListByIdQuery, ShoppingListDTO>
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public GetShoppingListByIdQueryHandler(
            IShoppingListRepository shoppingListRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public override async Task<ShoppingListDTO> Handle(GetShoppingListByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _shoppingListRepository.GetByID(request.Id);
            return ShoppingListDTO.CreateFromEntity(result);
        }
    }
}
