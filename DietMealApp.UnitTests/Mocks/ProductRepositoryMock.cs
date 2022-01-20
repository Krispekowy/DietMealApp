using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using DietMealApp.Core.Interfaces;
using DietMealApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace DietMealApp.UnitTests.Products.Mocks
{
    public class ProductRepositoryMock
    {
        //public static Mock<IProductRepository> GetProductRepository()
        //{
        //    var products = GetProducts();
        //    var mockProductRepository = new Mock<IProductRepository>();

        //    //mockProductRepository.Setup(repo => repo.Get().ToList()).Returns(products);

        //    mockProductRepository.Setup(repo => repo.GetByID(It.IsAny<Guid>()).Result).Returns(
        //        (Guid id) =>
        //        {
        //            var product = products.FirstOrDefault(a => a.Id == id);
        //            return product;
        //        });

        //    mockProductRepository.Setup(repo => repo.Insert(It.IsAny<Product>())).Callback<Product>((entity) => products.Add(entity));

        //    mockProductRepository.Setup(repo => repo.Delete(It.IsAny<Product>())).Callback<Product>((entity) => products.Remove(entity));

        //    mockProductRepository.Setup(repo => repo.Update(It.IsAny<Product>())).Callback<Product>((entity) => { products.Remove(entity); products.Add(entity); });

        //    return mockProductRepository;
        //}

        //private static List<Product> GetProducts()
        //{
        //    Product p1 = new Product()
        //    {
        //        Id = Guid.NewGuid(),
        //        ProductName = "Szynka",
        //        QuantityUnit = 100,
        //        Unit = Core.Enums.Unit.gram,
        //        Category = Core.Enums.ProductCategories.MiesoWedliny,
        //        Kcal = 150,
        //        PhotoPath = "//local/img/img1.png"
        //    };

        //    Product p2 = new Product()
        //    {
        //        Id = Guid.NewGuid(),
        //        ProductName = "Łosoś",
        //        QuantityUnit = 100,
        //        Unit = Core.Enums.Unit.gram,
        //        Category = Core.Enums.ProductCategories.RybyOwoceMorza,
        //        Kcal = 95,
        //        PhotoPath = "//local/img/img2.png"
        //    };

        //    Product p3 = new Product()
        //    {
        //        Id = Guid.NewGuid(),
        //        ProductName = "Mleko",
        //        QuantityUnit = 100,
        //        Unit = Core.Enums.Unit.mililitr,
        //        Category = Core.Enums.ProductCategories.Nabial,
        //        Kcal = 75,
        //        PhotoPath = "//local/img/img3.png"
        //    };

        //    Product p4 = new Product()
        //    {
        //        Id = Guid.NewGuid(),
        //        ProductName = "Brokuł",
        //        QuantityUnit = 100,
        //        Unit = Core.Enums.Unit.gram,
        //        Category = Core.Enums.ProductCategories.Warzywa,
        //        Kcal = 50,
        //        PhotoPath = "//local/img/img4.png"
        //    };

        //    Product p5 = new Product()
        //    {
        //        Id = Guid.NewGuid(),
        //        ProductName = "Jabłko",
        //        QuantityUnit = 100,
        //        Unit = Core.Enums.Unit.gram,
        //        Category = Core.Enums.ProductCategories.Owoce,
        //        Kcal = 37,
        //        PhotoPath = "//local/img/img5.png"
        //    };

        //    List<Product> p = new List<Product>
        //    {
        //        p1,
        //        p2,
        //        p3,
        //        p4,
        //        p5
        //    };

        //    return p;
        //}
    }
}
