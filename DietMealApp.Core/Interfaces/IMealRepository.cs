using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
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
        Task<List<Meal>> GetMealsByType(MealTimeType type);
        Task<List<Meal>> GetMealsByType(string user, MealTimeType type);
    }
}
