using DietMealApp.Core.Entities;
using DietMealApp.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.Interfaces
{
    public interface IProductRepository : _IBaseRepository<Product>
    {
    }
}
