using DietMealApp.Core.Entities;
using DietMealApp.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.Interfaces
{
    public interface IDietRepository:IBaseRepository<Diet>
    {
    }
}
