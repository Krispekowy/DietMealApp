using DietMealApp.Application.Commons.Abstract;
using DietMealApp.Application.Commons.Services.FileManager;
using DietMealApp.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietMealApp.Application.Functions.Shopping.Command.DeleteShoppingList
{
    public class DeleteShoppingListCommandHandler : BaseRequestHandler<DeleteShoppingListCommand, Unit>
    {
        private readonly IShoppingListRepository _shoppingListRepository;

        public DeleteShoppingListCommandHandler(
            IShoppingListRepository shoppingListRepository,
            IMediator mediator,
            IFileManager fileManager
            ) : base (mediator, fileManager)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public override async Task<Unit> Handle(DeleteShoppingListCommand request, CancellationToken cancellationToken)
        {
            await _shoppingListRepository.Delete(request.ShoppingListId);
            await _shoppingListRepository.CommitAsync();
            return Unit.Value;
        }
    }
}
