using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.DataAccessLayer.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
		void Delete(TEntity entityToDelete);

		Task Delete(Guid id);

		IQueryable<TEntity> Get();

		IQueryable<TEntity> Get(Func<TEntity, bool> filterCondition);

		bool Any(Func<TEntity, bool> filterCondition);

		void Update(TEntity entityToUpdate);

		Task<TEntity> GetByID(Guid id);

		void Insert(TEntity entity);

		void Commit();

		Task CommitAsync();
	}
}
