namespace Trazabilidad.Controllers
{
    using Domain.Models;
    using Trazabilidad.Helpers;

    using Resources.Strings;
    using Services.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using System.Linq;

   

    public class LocomotoraController : Controller
    {
        private ILocomotoraService _LocomotoraService;

        #region Constructor

        public LocomotoraController(ILocomotoraService LocomotoraSrvc)
        {
            _LocomotoraService = LocomotoraSrvc;
        }

        #endregion Constructor

        [HttpGet]
        public ActionResult List()
        {
            //ViewBag.LocomotiveType = this.GetTypeLocomotive();
            return View(_LocomotoraService.GetViewModelList());
        }

        // GET: Carro
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ViewModels.Models.Locomotora vLocomotora)
        {
            //TODO: Test this *revisar bien*
            if (!ModelState.IsValid)
            {
                return PartialView("~/Views/Locomotora/Partial/_Create", vLocomotora);
            }

            await _LocomotoraService.Save(vLocomotora);

            return Json(
                    new
                    {
                        success = true,
                        source = Resources.Strings.Models.Locomotora,
                        message = $"Locomotora {vLocomotora.Id} creado con éxito.",
                        data = this.RenderRazorViewToString("Partial/_Locomotora", vLocomotora)
                    });
        }

        public ActionResult LoadLocomotoraModal(int id)
        {
            var ptt = _LocomotoraService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Edit", ptt),
                    source = Models.Locomotora,
                    message = $"Locomotora obtenida con exito.",
                }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadLocomotoraModalxDel(int id)
        {
            var ptt = _LocomotoraService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Delete", ptt),
                    source = Models.Locomotora,
                    message = $"Locomotora obtenida con exito.",
                }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(ViewModels.Models.Locomotora Locomotoramom)
        {
            //ViewBag.LocomotiveType = this.GetTypeLocomotive();
            try
            {
                _LocomotoraService.Edit(Locomotoramom);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.Locomotora,
                            message = $"Locomotora modificada con éxito.",
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        source = Resources.Strings.Models.Locomotora,
                        message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                    });
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(ViewModels.Models.Locomotora Locomotoramov)
        {
            try
            {
                _LocomotoraService.Delete(Locomotoramov);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.Locomotora,
                            message = $"Locomotora eliminada con éxito.",
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                   new
                   {
                       success = false,
                       source = Resources.Strings.Models.Locomotora,
                       message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                   });
            }
        }
    }
}