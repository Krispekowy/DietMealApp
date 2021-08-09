using DietMealApp.Core.Entities;
using DietMealApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietMealApp.DataAccessLayer.Repositories
{
    public sealed class _BaseRepository : IDisposable
    {
        public AppDbContext _AppDbContext { get; set; }

        #region Repositories
        public IDietRepository dietRepository { get; set; }
        public IDayRepository dayRepository { get; set; }
        public IMealRepository mealRepository { get; set; }
        public IProductRepository productRepository { get; set; }


        #endregion

        public async void DisposeAsync()
		{
			await _AppDbContext.DisposeAsync().ConfigureAwait(false);
		}

		public void Dispose()
		{
			_AppDbContext.Dispose();
		}
	}
}
