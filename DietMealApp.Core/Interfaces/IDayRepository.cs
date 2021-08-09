using DietMealApp.Core.Entities;
using DietMealApp.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Interfaces
{
    public interface IDayRepository : _IBaseRepository<Day>
    {
        Task<List<Day>> GetDaysByUser(string user);
    }
}
