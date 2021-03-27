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
    class DietRepository : IDietRepository
    {
        private readonly AppDbContext dbContext;

        public DietRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Any(Func<Diet, bool> filterCondition)
        {
            return dbContext.Diets.Any(filterCondition);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Delete(Diet entityToDelete)
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

        public IQueryable<Diet> Get()
        {
            return dbContext.Diets.AsNoTracking().Where(a => !a.IsDeleted);
        }

        public IQueryable<Diet> Get(Func<Diet, bool> filterCondition)
        {
            return dbContext.Diets.AsNoTracking().Where(filterCondition).AsQueryable();
        }

        public async Task<Diet> GetByID(Guid id)
        {
            return await dbContext.Diets
                .Where(b => b.Id == id)
                .Include(d => d.Days)
                    .ThenInclude(ddm => ddm.DayDietMeals)
                        .ThenInclude(m => m.Meal)
                .FirstOrDefaultAsync();
        }

        public void Insert(Diet entity)
        {
            dbContext.Add(entity);
        }

        public void Update(Diet entityToUpdate)
        {
            dbContext.Update(entityToUpdate);
        }
    }
}
