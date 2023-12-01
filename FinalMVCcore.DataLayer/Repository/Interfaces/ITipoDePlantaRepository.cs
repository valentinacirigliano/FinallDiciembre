using FinalMVCcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMVCcore.DataLayer.Repository.Interfaces
{
    public interface ITipoDePlantaRepository : IRepository<TipoDePlanta>
    {
        void Update(TipoDePlanta tipoDePlanta);
        bool Exists(TipoDePlanta tipoDePlanta);
    }
}
