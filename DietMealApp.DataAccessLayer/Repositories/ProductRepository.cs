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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Any(Func<Product, bool> filterCondition)
        {
            return dbContext.Products.Any(filterCondition);
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Delete(Product entityToDelete)
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

        public IQueryable<Product> Get()
        {
            return dbContext.Products.AsNoTracking().Where(a => !a.IsDeleted);
        }

        public IQueryable<Product> Get(Func<Product, bool> filterCondition)
        {
            return dbContext.Products.AsNoTracking().Where(filterCondition).AsQueryable();
        }

        public async Task<Product> GetByID(Guid id)
        {
            return await dbContext.Products
                .AsNoTracking()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Insert(Product entity)
        {
            dbContext.Add(entity);
        }

        public IQueryable<Product> SearchProduct(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return dbContext.Products;
            }
            return dbContext.Products
                .Where(p => 
                p.ProductName
                    .Contains(searchTerm) ||
                p.Kcal.ToString()
                    .Contains(searchTerm));
        }

        public void Update(Product entityToUpdate)
        {
            dbContext.Update(entityToUpdate);
        }
    }
}
