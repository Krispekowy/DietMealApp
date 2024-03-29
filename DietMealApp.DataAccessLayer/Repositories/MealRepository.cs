﻿using DietMealApp.Core.Entities;
using DietMealApp.Core.Enums;
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
            return dbContext.Meals.Include(a=>a.MealProducts).ThenInclude(a=>a.Product).AsNoTracking().Where(a => a.IsDeleted != true);
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
                    .ThenInclude(x=>x.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Meal>> GetMealsByType(MealTimeType type)
        {
            return await dbContext.Meals
                .AsNoTracking()
                .Where(m => m.TypeOfMeal == type && !m.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Meal>> GetMealsByType(string user, MealTimeType type)
        {
            return await dbContext.Meals
                .AsNoTracking()
                .Where(m => m.TypeOfMeal == type && !m.IsDeleted && m.UserId == user)
                .ToListAsync();
        }

        public async Task<List<Meal>> GetMealsByQuery(string user, string query = "")
        {
            return await dbContext.Meals
                .Where(m => m.MealName.Contains(query) && !m.IsDeleted && m.UserId == user)
                .ToListAsync();
        }

        public async Task<List<Meal>> GetMealsByUser(string user)
        {
            return await dbContext.Meals
                .AsNoTracking()
                .Include(x=>x.MealProducts)
                    .ThenInclude(x=>x.Product)
                .Where(x => x.UserId == user && !x.IsDeleted).ToListAsync();
        }

        public void Insert(Meal entity)
        {
            dbContext.Add(entity);
        }

        public void Update(Meal entityToUpdate)
        {
            var existingMeal = dbContext.Meals
                .Where(x => x.Id == entityToUpdate.Id)
                .Include(m => m.MealProducts)
                .SingleOrDefault();

            if (existingMeal !=null)
            {
                // Update parent
                dbContext.Entry(existingMeal).CurrentValues.SetValues(entityToUpdate);

                // Delete children
                foreach (var existingMealProduct in existingMeal.MealProducts)
                {
                    if (!entityToUpdate.MealProducts.Any(c => c.MealId == existingMealProduct.MealId && c.ProductId == existingMealProduct.ProductId))
                        dbContext.MealProducts.Remove(existingMealProduct);
                }

                // Update and Insert children
                foreach (var newOrUpdateMealProduct in entityToUpdate.MealProducts)
                {
                    var existingMealProduct = existingMeal.MealProducts
                        .Where(c => c.MealId == newOrUpdateMealProduct.MealId && c.MealId != default(Guid) && c.ProductId == newOrUpdateMealProduct.ProductId && c.ProductId != default(Guid))
                        .SingleOrDefault();

                    if (existingMealProduct != null)
                        // Update child
                        dbContext.Entry(existingMealProduct).CurrentValues.SetValues(newOrUpdateMealProduct);
                    else
                    {
                        // Insert child
                        var newMealProduct = new MealProduct
                        {
                            MealId = newOrUpdateMealProduct.MealId,
                            ProductId = newOrUpdateMealProduct.ProductId,
                            Quantity = newOrUpdateMealProduct.Quantity
                        };
                        existingMeal.MealProducts.Add(newMealProduct);
                    }
                }
            }
        }
    }
}
