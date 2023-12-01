﻿using FinalMVCcore.DataLayer.Data;
using FinalMVCcore.DataLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalMVCcore.DataLayer.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> _dbSet;//work with the correctly dbset.        public Repository(ApplicationDbContext db)

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			_dbSet = _db.Set<T>();
		}

		public void Add(T entity)
		{
			_dbSet.Add(entity);
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public T Get(Expression<Func<T, bool>> filter, string? propertiesNames = null)
		{
			IQueryable<T> query = _dbSet;
			query = query.Where(filter);
			if (propertiesNames != null)
			{
				var properties = propertiesNames.Split(',', StringSplitOptions.RemoveEmptyEntries);
				foreach (var property in properties)
				{
					query = query.Include(property);
				}
			}

			return query.FirstOrDefault();
		}


		public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? propertiesNames = null)
		{
			IQueryable<T> query = _dbSet;
			if (filter != null)
			{
				query = query.Where(filter);

			}
			if (propertiesNames != null)
			{
				var properties = propertiesNames.Split(',', StringSplitOptions.RemoveEmptyEntries);
				foreach (var property in properties)
				{
					query = query.Include(property);
				}
			}
			return query.ToList();

		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			_dbSet.RemoveRange(entities);
		}
	}
}
