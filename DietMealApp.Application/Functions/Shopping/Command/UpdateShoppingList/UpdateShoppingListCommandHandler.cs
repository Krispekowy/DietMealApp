using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.DTO;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Command.UpdateShoppingList
{
    public class UpdateShoppingListCommandHandler : BaseRequestHandler<UpdateShoppingListCommand, Unit>
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public UpdateShoppingListCommandHandler(
            IShoppingListRepository shoppingListRepository,
            IMediator mediator,
            IFileManager fileManager) : base(mediator, fileManager)
        {
            _shoppingListRepository = shoppingListRepository;
        }
        public override async Task<Unit> Handle(UpdateShoppingListCommand request, CancellationToken cancellationToken)
        {
            var entity = ShoppingList.CreateFromDto(request.ShoppingList);
            _shoppingListRepository.Update(entity);
            await _shoppingListRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
