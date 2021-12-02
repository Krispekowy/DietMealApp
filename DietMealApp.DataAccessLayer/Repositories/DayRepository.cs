using DietMealApp.Core.Entities;
using DietMealApp.Core.Interfaces;
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
            var entityToDelete = await GetByID(id);
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
            dbContext.Days.Update(entityToUpdate);
        }
    }
}
