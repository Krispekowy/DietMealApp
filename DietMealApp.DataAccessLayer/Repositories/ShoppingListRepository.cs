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
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly AppDbContext _dbContext;

        public ShoppingListRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Any(Func<ShoppingList, bool> filterCondition)
        {
            return _dbContext.ShoppingList.Any(filterCondition);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(ShoppingList entityToDelete)
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

        public IQueryable<ShoppingList> Get()
        {
            return _dbContext.ShoppingList.AsNoTracking().Where(a => !a.IsDeleted);
        }

        public IQueryable<ShoppingList> Get(Func<ShoppingList, bool> filterCondition)
        {
            return _dbContext.ShoppingList.AsNoTracking().Where(filterCondition).AsQueryable();
        }

        public async Task<ShoppingList> GetByID(Guid id)
        {
            return await _dbContext.ShoppingList
                    .Include(a=>a.ShoppingListDays)
                    .Include(a=>a.ShoppingListMeals)
                    .Include(a=>a.ShoppingListProducts)
                        .ThenInclude(b=>b.Product)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Insert(ShoppingList entity)
        {
            _dbContext.Add(entity);
        }

        public void Update(ShoppingList entityToUpdate)
        {
            _dbContext.ShoppingList.Update(entityToUpdate);
        }
    }
}
