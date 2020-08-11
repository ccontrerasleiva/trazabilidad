namespace Trazabilidad.Controllers
{
    using Trazabilidad.Helpers;
    using Resources.Strings;
    using Services.Interfaces;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    public class CarroController : Controller
    {
        private ICarroService _CarroService;


        #region Constructor

        public CarroController(ICarroService CarroSrvc)
        {
            _CarroService = CarroSrvc;
        }

        #endregion Constructor

        [HttpGet]
        public ActionResult List()
        {
            //ViewBag.estaciones = this.GetStations();
            return View(_CarroService.GetViewModelList());
        }

        // GET: Carro
        public ActionResult Index()
        {
            return View();
        }

        // GET: Carro/Details/5
  

        [HttpPost]
        public async Task<ActionResult> Create(ViewModels.Models.Carro vCarro)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return PartialView("~/Views/Carro/Partial/_Create", vCarro);
                }
                await _CarroService.Save(vCarro);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.Carro,
                            message = $"Carro creado con éxito.",
                            data = this.RenderRazorViewToString("Partial/_Carro", vCarro)
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        source = Resources.Strings.Models.Carro,
                        message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                    });
            }
        }

        [HttpPost]
        public ActionResult Edit(ViewModels.Models.Carro carromom)
        {
            try
            {
                _CarroService.Edit(carromom);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.Carro,
                            message = $"Carro modificada con éxito.",
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        source = Resources.Strings.Models.Carro,
                        message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                    });
            }
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult LoadCarroModal(int id)
        {
            
            //ViewBag.estacion = this.GetStations();
            var ptt = _CarroService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Edit", ptt),
                    source = Models.Carro,
                    message = $"Carro obtenido con exito.",
                }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadCarroModalxDel(int id)
        {
            var ptt = _CarroService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Delete", ptt),
                    source = Models.Carro,
                    message = $"Carro obtenido con exito.",
                }, JsonRequestBehavior.AllowGet);
        }



    }
}
