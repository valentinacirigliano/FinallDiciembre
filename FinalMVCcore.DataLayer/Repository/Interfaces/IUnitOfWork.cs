using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMVCcore.DataLayer.Repository.Interfaces
{
	public interface IUnitOfWork
	{
		IPlantaRepository Plantas { get; }
		ITipoDePlantaRepository TiposDePlantas { get; }

		void Save();
		void BeginTransaction();
		void CommitTransaction();
		void RollbackTransaction();
	}
}
