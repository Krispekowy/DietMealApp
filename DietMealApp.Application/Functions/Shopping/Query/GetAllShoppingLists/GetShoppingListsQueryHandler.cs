using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.DTO;
using DietMealApp.Core.DTO.ShoppingList;
using DietMealApp.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Query.GetAllShoppingLists
{
    public class GetShoppingListsQueryHandler : BaseRequestHandler<GetShoppingListsQuery, List<ShoppingListDTO>>
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public GetShoppingListsQueryHandler(
            IShoppingListRepository shoppingListRepository,
            IMediator mediator,
            IFileManager fileManager
            ) : base (mediator, fileManager)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public override async Task<List<ShoppingListDTO>> Handle(GetShoppingListsQuery request, CancellationToken cancellationToken)
        {
            var result = await _shoppingListRepository.Get().ToListAsync();
            return result.Select(a=> ShoppingListDTO.CreateFromEntity(a)).ToList();
        }
    }
}
