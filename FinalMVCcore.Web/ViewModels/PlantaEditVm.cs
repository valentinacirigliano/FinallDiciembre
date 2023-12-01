using FinalMVCcore.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalMVCcore.Web.ViewModels
{
    public class PlantaEditVm
    {
        public Planta Planta { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TiposDePlantas { get; set; }
    }
}
