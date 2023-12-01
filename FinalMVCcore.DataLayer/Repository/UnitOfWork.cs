using FinalMVCcore.DataLayer.Data;
using FinalMVCcore.DataLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMVCcore.DataLayer.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;

		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			TiposDePlantas = new TipoDePlantaRepository(_db);
			Plantas = new PlantaRepository(_db);
		}

		public IPlantaRepository Plantas { get; private set; }
		public ITipoDePlantaRepository TiposDePlantas { get; private set; }
		public void BeginTransaction()
		{
			_db.Database.BeginTransaction();
		}

		public void CommitTransaction()
		{
			_db.Database.CommitTransaction();
		}

		public void RollbackTransaction()
		{
			_db.Database.RollbackTransaction();
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
