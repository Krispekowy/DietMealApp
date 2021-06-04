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
    public class MealRepository : IMealRepository
    {
        private readonly AppDbContext dbContext;

        public MealRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Any(Func<Meal, bool> filterCondition)
        {
            return dbContext.Meals.Any(filterCondition);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Delete(Meal entityToDelete)
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

        public IQueryable<Meal> Get()
        {
            return dbContext.Meals.AsNoTracking().Where(a => !a.IsDeleted);
        }

        public IQueryable<Meal> Get(Func<Meal, bool> filterCondition)
        {
            return dbContext.Meals.AsNoTracking().Where(filterCondition).AsQueryable();
        }

        public async Task<Meal> GetByID(Guid id)
        {
            return await dbContext.Meals
                .AsNoTracking()
                .Include(x => x.MealProducts)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Meal>> GetMealsByUser(string user)
        {
            return await dbContext.Meals.Where(x => x.UserId == user).ToListAsync();
        }

        public void Insert(Meal entity)
        {
            dbContext.Add(entity);
        }

        public void Update(Meal entityToUpdate)
        {
            dbContext.Update(entityToUpdate);
        }
    }
}
