namespace Trazabilidad.Controllers
{
    using Trazabilidad.Helpers;
    using Resources.Strings;
    using Services.Interfaces;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    public class ContenedorController : Controller
    {
        private IContenedorService _ContenedorService;


        #region Constructor

        public ContenedorController(IContenedorService ContenedorSrvc)
        {
            _ContenedorService = ContenedorSrvc;
        }

        #endregion Constructor

        [HttpGet]
        public ActionResult List()
        {
            //ViewBag.estaciones = this.GetStations();
            return View(_ContenedorService.GetViewModelList());
        }

        // GET: Contenedor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contenedor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(ViewModels.Models.Contenedor vContenedor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return PartialView("~/Views/Contenedor/Partial/_Create", vContenedor);
                }
                await _ContenedorService.Save(vContenedor);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.Contenedor,
                            message = $"Contenedor creado con éxito.",

                            data = this.RenderRazorViewToString("Partial/_Contenedor", vContenedor)
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        source = Resources.Strings.Models.Contenedor,
                        message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                    });
            }
        }



        [HttpPost]
        public ActionResult Edit(ViewModels.Models.Contenedor Contenedormom)
        {
            try
            {
                _ContenedorService.Edit(Contenedormom);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.Contenedor,
                            message = $"Contenedor modificada con éxito.",
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        source = Resources.Strings.Models.Contenedor,
                        message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                    });
            }
        }


        // GET: Contenedor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        public ActionResult LoadContenedorModal(int id)
        {
            
            //ViewBag.estacion = this.GetStations();
            var ptt = _ContenedorService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Edit", ptt),
                    source = Models.Contenedor,
                    message = $"Contenedor obtenido con exito.",
                }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadContenedorModalxDel(int id)
        {
            var ptt = _ContenedorService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Delete", ptt),
                    source = Models.Contenedor,
                    message = $"Contenedor obtenido con exito.",
                }, JsonRequestBehavior.AllowGet);
        }



    }
}
