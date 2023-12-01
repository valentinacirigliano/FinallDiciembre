using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMVCcore.Models
{
    public class TipoDePlanta
    {
        [Key]
        public int TipoPlantaId { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
    }
}
