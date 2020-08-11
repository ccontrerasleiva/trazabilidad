namespace Trazabilidad.Controllers
{
    using Trazabilidad.Helpers;
    using Resources.Strings;
    using Services.Interfaces;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    //[Authorize]

    public class ConductorController : Controller
    {
        private IConductorService _ConductorService;

        #region Constructor

        public ConductorController(IConductorService ConductorSrvc)
        {
            _ConductorService = ConductorSrvc;
        }

        #endregion Constructor

        [HttpGet]
        public ActionResult List()
        {
            //ViewBag.ConductorType = this.GetTypeConductor();
            return View(_ConductorService.GetViewModelList());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ViewModels.Models.Conductor Conductormom)
        {
            try
            {
                _ConductorService.Edit(Conductormom);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.Conductor,
                            message = $"Conductor modificada con éxito.",
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        source = Resources.Strings.Models.Conductor,
                        message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                    });
            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        } 

        [HttpPost]
        public async Task<ActionResult> Create(ViewModels.Models.Conductor vConductor)
        {
            //TODO: Test this *revisar bien*
            if (!ModelState.IsValid)
            {
                return PartialView("~/Views/Conductor/Partial/_Create", vConductor);
            }

            await _ConductorService.Save(vConductor);

            return Json(
                    new
                    {
                        success = true,
                        source = Resources.Strings.Models.Conductor,
                        message = $"Conductor {vConductor.Id} creado con éxito.",
                        data = this.RenderRazorViewToString("Partial/_Conductor", vConductor)
                    });
        }
        // GET: Conductor/Edit/5

        public ActionResult LoadConductorModal(int id)
        {
            var ptt = _ConductorService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Edit", ptt),
                    source = Models.Conductor,
                    message = $"Conductor obtenida con exito.",
                }, JsonRequestBehavior.AllowGet);
        }
       
        

       
    }
}