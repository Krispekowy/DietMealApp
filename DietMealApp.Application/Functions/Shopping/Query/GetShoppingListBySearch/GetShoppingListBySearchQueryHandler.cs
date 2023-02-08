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

namespace DietMealApp.Application.Functions.Shopping.Query.GetShoppingListBySearch
{
    public class GetShoppingListBySearchQueryHandler : BaseRequestHandler<GetShoppingListBySearchQuery, List<ShoppingListDTO>>
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public GetShoppingListBySearchQueryHandler(
            IShoppingListRepository shoppingListRepository,
            IMediator mediator,
            IFileManager fileManager
            ) : base(mediator, fileManager)
        {
            _shoppingListRepository = shoppingListRepository;
        }
        public override async Task<List<ShoppingListDTO>> Handle(GetShoppingListBySearchQuery request, CancellationToken cancellationToken)
        {
            var shoppingLists = await _shoppingListRepository.Get(a => a.Name.Contains(request.Query)).ToListAsync();
            return shoppingLists.Select(a => ShoppingListDTO.CreateFromEntity(a)).ToList();
        }
    }
}
