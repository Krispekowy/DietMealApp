using DietMealApp.Core.Entities;
using DietMealApp.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Interfaces
{
    public interface IMealRepository: _IBaseRepository<Meal>
    {
        Task<List<Meal>> GetMealsByUser(string user);
    }
}
