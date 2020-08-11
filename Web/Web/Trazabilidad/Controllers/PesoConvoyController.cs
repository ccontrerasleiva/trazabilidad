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

   

    public class PesoConvoyController : Controller
    {
        private IPesoConvoyService _PesoConvoyService;

        #region Constructor

        public PesoConvoyController(IPesoConvoyService PesoConvoySrvc)
        {
            _PesoConvoyService = PesoConvoySrvc;
        }

        #endregion Constructor

        [HttpGet]
        public ActionResult List()
        {
            //ViewBag.LocomotiveType = this.GetTypeLocomotive();
            return View(_PesoConvoyService.GetViewModelList());
        }

        // GET: PesoConvoy
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ViewModels.Models.PesoConvoy vPesoConvoy)
        {
            //TODO: Test this *revisar bien*
            if (!ModelState.IsValid)
            {
                return PartialView("~/Views/PesoConvoy/Partial/_Create", vPesoConvoy);
            }

            await _PesoConvoyService.Save(vPesoConvoy);

            return Json(
                    new
                    {
                        success = true,
                        source = Resources.Strings.Models.PesoConvoy,
                        message = $"Locomotora {vPesoConvoy.Id} creado con éxito.",
                        data = this.RenderRazorViewToString("Partial/_PesoConvoy", vPesoConvoy)
                    });
        }

        public ActionResult LoadPesoConvoyModal(int id)
        {
            var ptt = _PesoConvoyService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Edit", ptt),
                    source = Models.PesoConvoy,
                    message = $"Peso Convoy obtenida con exito.",
                }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadPesoConvoyModalxDel(int id)
        {
            var ptt = _PesoConvoyService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Delete", ptt),
                    source = Models.PesoConvoy,
                    message = $"PesoConvoy obtenida con exito.",
                }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(ViewModels.Models.PesoConvoy PesoConvoymom)
        {
            //ViewBag.LocomotiveType = this.GetTypeLocomotive();
            try
            {
                _PesoConvoyService.Edit(PesoConvoymom);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.PesoConvoy,
                            message = $"PesoConvoy modificada con éxito.",
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        source = Resources.Strings.Models.PesoConvoy,
                        message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                    });
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult Delete(ViewModels.Models.PesoConvoy PesoConvoymov)
        //{
        //    try
        //    {
        //        _PesoConvoyService.Delete(PesoConvoymov);

        //        return Json(
        //                new
        //                {
        //                    success = true,
        //                    source = Models.PesoConvoy,
        //                    message = $"PesoConvoy eliminada con éxito.",
        //                });
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return Json(
        //           new
        //           {
        //               success = false,
        //               source = Resources.Strings.Models.PesoConvoy,
        //               message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
        //           });
        //    }
        //}
    }
}