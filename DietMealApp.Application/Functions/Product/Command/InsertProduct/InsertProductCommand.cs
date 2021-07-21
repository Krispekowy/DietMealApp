using DietMealApp.Core.DTO.Products;
using MediatR;

namespace DietMealApp.Service.Functions.Command
{
    public class InsertProductCommand : IRequest<Unit>
    {
        public ProductDTO Product { get; set; }
    }
}
