using FinalMVCcore.DataLayer.Data;
using FinalMVCcore.DataLayer.Repository.Interfaces;
using FinalMVCcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMVCcore.DataLayer.Repository
{
    public class PlantaRepository : Repository<Planta>, IPlantaRepository
    {
        private readonly ApplicationDbContext _db;
        public PlantaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool Exists(Planta Planta)
        {
            if (Planta.PlantaId == 0)
            {
                return _db.Plantas.Any(c => c.Descripcion == Planta.Descripcion);
            }
            return _db.Plantas.Any(c => c.Descripcion == Planta.Descripcion &&
                                        c.PlantaId != Planta.PlantaId);
        }


        public void Update(Planta Planta)
        {
            _db.Plantas.Update(Planta);
        }
    }
}
