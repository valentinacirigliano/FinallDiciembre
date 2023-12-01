﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalMVCcore.DataLayer.Repository.Interfaces
{
	public interface IRepository<T> where T : class
	{
		T Get(Expression<Func<T, bool>> filter, string? propertiesNames = null);
		IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? propertiesNames = null);
		void Add(T entity);
		void Delete(T entity);
		void RemoveRange(IEnumerable<T> entities);
	}
}
