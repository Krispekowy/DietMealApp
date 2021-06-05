using AutoMapper;
using DietMealApp.Core.DTO.Products;
using DietMealApp.Core.Interfaces;
using DietMealApp.Core.Mappings;
using DietMealApp.Service.Functions.Query;
using DietMealApp.UnitTests.Products.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DietMealApp.UnitTests.Products.Queries
{
    public class GetAllProductsQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockProductRepository;
        public GetAllProductsQueryTest()
        {
            _mockProductRepository = ProductRepositoryMock.GetProductRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiler>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task GetAllProductsListTest()
        {
            var handler = new GetAllProductsQueryHandler(_mockProductRepository.Object, _mapper);

            var result = await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<ProductDTO>>();

            result.Count.ShouldBe(5);
        }
    }
}
