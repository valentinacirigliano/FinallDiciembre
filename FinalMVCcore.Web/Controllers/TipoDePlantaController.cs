using FinalMVCcore.DataLayer.Repository.Interfaces;
using FinalMVCcore.Models;
using FinalMVCcore.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalMVCcore.Web.Controllers
{
    public class TipoDePlantaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoDePlantaController(IUnitOfWork unitOfWork)
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
            var tipoDePlanta = new TipoDePlanta();

            if (id == null || id == 0)
            {
                return View(tipoDePlanta);

            }
            else
            {
                tipoDePlanta = _unitOfWork.TiposDePlantas.Get(p => p.TipoPlantaId == id.Value);

                return View(tipoDePlanta);

            }
        }
        [HttpPost]
        public IActionResult Upsert(TipoDePlanta tipoDePlanta)
        {
            if (!ModelState.IsValid)
            {
                var tipoPlanta = new TipoDePlanta();

                return View(tipoPlanta);
            }

            if (tipoDePlanta.TipoPlantaId == 0)
            {
                _unitOfWork.TiposDePlantas.Add(tipoDePlanta);
                _unitOfWork.Save();
                TempData["success"] = "Tipo de Planta agregada exitosamente!!";
            }
            else
            {
                _unitOfWork.TiposDePlantas.Update(tipoDePlanta);
                _unitOfWork.Save();
                TempData["success"] = "Tipo de Planta editada exitosamente!!";
            }

            return RedirectToAction("Index");
        }


        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var tiposDePlantas = _unitOfWork.TiposDePlantas.GetAll();
            return Json(new { data = tiposDePlantas });

        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return Json(new { success = false, message = "Not Found" });

            }
            var tipoPlantaDelete = _unitOfWork.TiposDePlantas.Get(p => p.TipoPlantaId == id);
            if (tipoPlantaDelete == null)
            {
                return Json(new { success = false, message = "Tipo De Planta no encontrado" });
            }
            try
            {
                _unitOfWork.TiposDePlantas.Delete(tipoPlantaDelete);
                _unitOfWork.Save();
                TempData["success"] = "Registro borrado exitosamente!!";
                return Json(new { success = true, message = "Tipo De Planta Eliminado exitosamente" });

            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
        }
        #endregion
    }
}
