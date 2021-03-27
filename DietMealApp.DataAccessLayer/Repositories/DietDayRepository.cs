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
    class DietDayRepository : IDietDayRepository
    {
        private AppDbContext dbContext;

        public DietDayRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Any(Func<DietDay, bool> filterCondition)
        {
            return dbContext.DietDays.Any(filterCondition);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Delete(DietDay entityToDelete)
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

        public IQueryable<DietDay> Get()
        {
            return dbContext.DietDays.AsNoTracking().Where(a => !a.IsDeleted);
        }

        public IQueryable<DietDay> Get(Func<DietDay, bool> filterCondition)
        {
            return dbContext.DietDays.AsNoTracking().Where(filterCondition).AsQueryable();
        }

        public async Task<DietDay> GetByID(Guid id)
        {
            return await dbContext.DietDays
                .Include(a=>a.DayDietMeals)
                .Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public void Insert(DietDay entity)
        {
            dbContext.Add(entity);
        }

        public void Update(DietDay entityToUpdate)
        {
            dbContext.DietDays.Update(entityToUpdate);
        }
    }
}
