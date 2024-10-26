using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Context;

namespace WinFormsApp1.Repository
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private readonly AppDbContext _dbContext;
		protected DbSet<TEntity> DbSet;

		public Repository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
			DbSet = dbContext.Set<TEntity>();
		}

		public async Task<TEntity> CreateAsync(TEntity entity)
		{
			var entry = await DbSet.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return entry.Entity;
		}

		public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
			=> await DbSet.FirstOrDefaultAsync(expression);
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.

#pragma warning disable CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
		public async Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression)
#pragma warning restore CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
		{
			if (expression == null)
				return DbSet;
			return DbSet.Where(expression);
		}
		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			var entry = DbSet.Update(entity);
			await _dbContext.SaveChangesAsync();
			return entry.Entity;
		}

		public async Task<bool> DeleteAsync(TEntity entity)
		{
#pragma warning disable CS0168 // Переменная объявлена, но не используется
			try
			{
				DbSet.Remove(entity);
				await _dbContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
#pragma warning restore CS0168 // Переменная объявлена, но не используется
		}
	}
}
