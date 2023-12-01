using FinalMVCcore.DataLayer.Data;
using FinalMVCcore.DataLayer.Repository.Interfaces;
using FinalMVCcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalMVCcore.DataLayer.Repository
{
    public class TipoDePlantaRepository : Repository<TipoDePlanta>, ITipoDePlantaRepository
    {
        private readonly ApplicationDbContext _db;
        public TipoDePlantaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool Exists(TipoDePlanta TipoDePlanta)
        {
            if (TipoDePlanta.TipoPlantaId == 0)
            {
                return _db.TiposDePlantas.Any(c => c.Descripcion == TipoDePlanta.Descripcion);
            }
            return _db.TiposDePlantas.Any(c => c.Descripcion == TipoDePlanta.Descripcion &&
            c.TipoPlantaId != TipoDePlanta.TipoPlantaId);
        }


        public void Update(TipoDePlanta TipoDePlanta)
        {
            _db.TiposDePlantas.Update(TipoDePlanta);
        }
    }

}
