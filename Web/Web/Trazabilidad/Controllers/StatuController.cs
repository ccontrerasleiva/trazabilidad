namespace Trazabilidad.Controllers
{
    using Trazabilidad.Helpers;
    using Resources.Strings;
    using Services.Interfaces;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    public class StatuController : Controller
    {
        private IStatuService _StatuService;


        #region Constructor

        public StatuController(IStatuService StatuSrvc)
        {
            _StatuService = StatuSrvc;
        }

        #endregion Constructor

        [HttpGet]
        public ActionResult List()
        {
            //ViewBag.estaciones = this.GetStations();
            return View(_StatuService.GetViewModelList());
        }

        // GET: Statu
        public ActionResult Index()
        {
            return View();
        }

        // GET: Statu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(ViewModels.Models.Statu vStatu)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return PartialView("~/Views/Statu/Partial/_Create", vStatu);
                }
                await _StatuService.Save(vStatu);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.Statu,
                            message = $"Statu creado con éxito.",
                            data = this.RenderRazorViewToString("Partial/_Statu", vStatu)
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        source = Resources.Strings.Models.Statu,
                        message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                    });
            }
        }



        [HttpPost]
        public ActionResult Edit(ViewModels.Models.Statu Statumom)
        {
            try
            {
                _StatuService.Edit(Statumom);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.Statu,
                            message = $"Statu modificada con éxito.",
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        source = Resources.Strings.Models.Statu,
                        message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                    });
            }
        }


        // GET: Statu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        public ActionResult LoadStatuModal(int id)
        {
            
            //ViewBag.estacion = this.GetStations();
            var ptt = _StatuService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Edit", ptt),
                    source = Models.Statu,
                    message = $"Statu obtenido con exito.",
                }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadStatuModalxDel(int id)
        {
            var ptt = _StatuService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Delete", ptt),
                    source = Models.Statu,
                    message = $"Statu obtenido con exito.",
                }, JsonRequestBehavior.AllowGet);
        }



    }
}
