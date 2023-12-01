using FinalMVCcore.DataLayer.Repository.Interfaces;
using FinalMVCcore.Models;
using FinalMVCcore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;

namespace FinalMVCcore.Web.Controllers
{
    public class PlantaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlantaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult UpSert(int? id)
        {
            var plantaVm = new PlantaEditVm
            {
                Planta = new Planta(),
                TiposDePlantas = _unitOfWork.TiposDePlantas
                    .GetAll()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Descripcion,
                        Value = c.TipoPlantaId.ToString()
                    })
            };

            if (id == null || id == 0)
            {
                return View(plantaVm);

            }
            else
            {
                plantaVm.Planta = _unitOfWork.Plantas.Get(p => p.PlantaId == id.Value);

                return View(plantaVm);

            }
        }
        [HttpPost]
        public IActionResult Upsert(PlantaEditVm plantaVm)
        {
            if (!ModelState.IsValid)
            {
                plantaVm.TiposDePlantas = _unitOfWork.TiposDePlantas
                    .GetAll()
                    .Select(c => new SelectListItem
                    {
                        Text = c.Descripcion,
                        Value = c.TipoPlantaId.ToString()
                    });

                return View(plantaVm);
            }

            if (plantaVm.Planta.PlantaId == 0)
            {
                _unitOfWork.Plantas.Add(plantaVm.Planta);
                _unitOfWork.Save();
                TempData["success"] = "Planta agregada exitosamente!!";
            }
            else
            {
                _unitOfWork.Plantas.Update(plantaVm.Planta);
                _unitOfWork.Save();
                TempData["success"] = "Planta editada exitosamente!!";
            }

            return RedirectToAction("Index");
        }


        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var plantaList = _unitOfWork.Plantas.GetAll();
            List<PlantaListVm> plantaListVm = new List<PlantaListVm>();
            foreach (var planta in plantaList)
            {
                var plantaVm = new PlantaListVm()
                {
                    id = planta.PlantaId,
                    Descripcion = planta.Descripcion,
                    Precio = planta.Precio,
                    TipoDePlanta = (_unitOfWork.TiposDePlantas.Get(c => c.TipoPlantaId == planta.TipoDePlantaId)).Descripcion
                };
                plantaListVm.Add(plantaVm);

            }
            return Json(new { data = plantaListVm });

        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return Json(new { success = false, message = "Not Found" });

            }
            var productDelete = _unitOfWork.Plantas.Get(p => p.PlantaId == id);
            if (productDelete == null)
            {
                return Json(new { success = false, message = "Planta no encontrada" });
            }
            try
            {
                _unitOfWork.Plantas.Delete(productDelete);
                _unitOfWork.Save();
                TempData["success"] = "Registro borrado exitosamente!!";
                return Json(new { success = true, message = "Planta Eliminada exitosamente" });

            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
        }
        #endregion

    }
}
