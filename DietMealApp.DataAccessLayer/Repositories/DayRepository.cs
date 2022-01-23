using DietMealApp.Core.Entities;
using DietMealApp.Core.Interfaces;
using DietMealApp.Core.Intersections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.DataAccessLayer.Repositories
{
    public class DayRepository : IDayRepository
    {
        private AppDbContext dbContext;

        public DayRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Any(Func<Day, bool> filterCondition)
        {
            return dbContext.Days.Any(filterCondition);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Delete(Day entityToDelete)
        {
            entityToDelete.IsDeleted = true;
            entityToDelete.DeleteDate = DateTime.Now;
            Update(entityToDelete);
        }

        public async Task Delete(Guid id)
        {
            var entityToDelete = Get(a=>a.Id == id).FirstOrDefault();
            entityToDelete.IsDeleted = true;
            entityToDelete.DeleteDate = DateTime.Now;
            Update(entityToDelete);
        }

        public IQueryable<Day> Get()
        {
            return dbContext.Days.AsNoTracking().Where(a => !a.IsDeleted);
        }

        public IQueryable<Day> Get(Func<Day, bool> filterCondition)
        {
            return dbContext.Days.AsNoTracking().Where(filterCondition).AsQueryable();
        }

        public async Task<Day> GetByID(Guid id)
        {
            return await dbContext.Days
                .AsNoTracking()
                .Where(a => a.Id == id)
                .Include(a => a.DayMeals)
                    .ThenInclude(a=>a.Meal)
                        .ThenInclude(a=>a.MealProducts)
                            .ThenInclude(a=>a.Product)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Day>> GetDaysByUser(string user)
        {
            return await dbContext.Days.AsNoTracking()
                .Include(a => a.DayMeals)
                    .ThenInclude(a=>a.Meal)
                        .ThenInclude(a=>a.MealProducts)
                            .ThenInclude(a=>a.Product)
                .Include(a => a.DietDays)
                .Where(a => !a.IsDeleted)
                .ToListAsync();
        }

        public void Insert(Day entity)
        {
            dbContext.Add(entity);
        }

        public void Update(Day entityToUpdate)
        {
            var existingDay = dbContext.Days
                .Where(x => x.Id == entityToUpdate.Id)
                .Include(m => m.DayMeals)
                .SingleOrDefault();

            if (existingDay != null)
            {
                // Update parent
                dbContext.Entry(existingDay).CurrentValues.SetValues(entityToUpdate);

                // Delete children
                foreach (var existingDayMeals in existingDay.DayMeals)
                {
                    if (!entityToUpdate.DayMeals.Any(c => c.MealId == existingDayMeals.MealId && c.DayId == existingDayMeals.DayId))
                        dbContext.DayMeals.Remove(existingDayMeals);
                }

                // Update and Insert children
                foreach (var newOrUpdateDayMeals in entityToUpdate.DayMeals)
                {
                    var existingDayMeal = existingDay.DayMeals
                        .Where(c => c.MealId == newOrUpdateDayMeals.MealId && c.MealId != default(Guid) && c.DayId == newOrUpdateDayMeals.DayId && c.DayId != default(Guid))
                        .SingleOrDefault();

                    if (existingDayMeal != null)
                        // Update child
                        dbContext.Entry(existingDayMeal).CurrentValues.SetValues(newOrUpdateDayMeals);
                    else
                    {
                        // Insert child
                        var newDayMeal = new DayMeals
                        {
                            MealId = newOrUpdateDayMeals.MealId,
                            DayId = newOrUpdateDayMeals.DayId,
                            Type = newOrUpdateDayMeals.Type
                        };
                        existingDay.DayMeals.Add(newDayMeal);
                    }
                }
            }
        }
    }
}
