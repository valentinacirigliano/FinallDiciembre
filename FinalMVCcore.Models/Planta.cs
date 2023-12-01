using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalMVCcore.Models
{
    public class Planta
    {
        [Key]
        public int PlantaId { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        [ForeignKey("TipoDePlanta")]
        [DisplayName("Tipo de Planta")]
        public int TipoDePlantaId { get; set; }
        [Required]
        [Range(1, 10000)]
        public decimal Precio { get; set; }
    }
}
