using FinalMVCcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMVCcore.DataLayer.Repository.Interfaces
{
    public interface IPlantaRepository : IRepository<Planta>
    {
        void Update(Planta planta);
        bool Exists(Planta planta);
    }
}
