namespace Trazabilidad.Controllers
{
    using Trazabilidad.Helpers;
    using Resources.Strings;
    using Services.Interfaces;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    [Authorize]

    public class RutaController : Controller
    {

        private IRutaService _RutaService;

        //private IItinerarioService _ItinerarioService;

        #region Constructor
        public RutaController(IRutaService RutaService)
        {

            _RutaService = RutaService;

        }
        #endregion

        [HttpGet]
        public ActionResult List()
        {
            return View(_RutaService.GetViewModelList());
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ViewModels.Models.Ruta vRuta)
        {
            //TODO: Test this *revisar bien*
            if (!ModelState.IsValid)
            {
                return PartialView("~/Views/Ruta/Partial/_Create", vRuta);
            }

            await _RutaService.Save(vRuta);

            return Json(
                    new
                    {
                        success = true,
                        source = Resources.Strings.Models.Ruta,
                        message = $"Ruta {vRuta.Id} creado con éxito.",
                        data = this.RenderRazorViewToString("Partial/_Ruta", vRuta)
                    });
        }

        public ActionResult LoadRutaModal(int id)
        {
            var ptt = _RutaService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Edit", ptt),
                    source = Models.Ruta,
                    message = $"Ruta obtenida con exito.",
                }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadRutaModalxDel(int id)
        {
            var ptt = _RutaService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Delete", ptt),
                    source = Models.Ruta,
                    message = $"Ruta obtenida con exito.",
                }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(ViewModels.Models.Ruta Rutamom)
        {
            try
            {
                _RutaService.Edit(Rutamom);


                return Json(
                        new
                        {
                            success = true,
                            source = Models.Ruta,
                            message = $"Ruta modificada con éxito.",
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        source = Resources.Strings.Models.Ruta,
                        message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                    });
            }

        }

        [HttpPost]
        public ActionResult Delete(ViewModels.Models.Ruta Rutamov)
        {
            try
            {
                _RutaService.Delete(Rutamov);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.Ruta,
                            message = $"Ruta eliminada con éxito.",
                        });
            }
            catch (System.Exception ex)
            {

                return Json(
                   new
                   {
                       success = false,
                       source = Resources.Strings.Models.Ruta,
                       message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                   });
            }
        }

    }
}
