namespace Trazabilidad.Controllers
{
    using Trazabilidad.Helpers;
    using Resources.Strings;
    using Services.Interfaces;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    public class TagController : Controller
    {
        private ITagService _TagService;


        #region Constructor

        public TagController(ITagService TagSrvc)
        {
            _TagService = TagSrvc;
        }

        #endregion Constructor

        [HttpGet]
        public ActionResult List()
        {
            //ViewBag.estaciones = this.GetStations();
            return View(_TagService.GetViewModelList());
        }

        // GET: Tag
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tag/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(ViewModels.Models.Tag vTag)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return PartialView("~/Views/Tag/Partial/_Create", vTag);
                }
                await _TagService.Save(vTag);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.Tag,
                            message = $"Tag creado con éxito.",
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        source = Resources.Strings.Models.Tag,
                        message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                    });
            }
        }



        [HttpPost]
        public ActionResult Edit(ViewModels.Models.Tag Tagmom)
        {
            try
            {
                _TagService.Edit(Tagmom);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.Tag,
                            message = $"Tag modificada con éxito.",
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        source = Resources.Strings.Models.Tag,
                        message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                    });
            }
        }


        // GET: Tag/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        public ActionResult LoadTagModal(int id)
        {
            
            //ViewBag.estacion = this.GetStations();
            var ptt = _TagService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Edit", ptt),
                    source = Models.Tag,
                    message = $"Tag obtenido con exito.",
                }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadTagModalxDel(int id)
        {
            var ptt = _TagService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Delete", ptt),
                    source = Models.Tag,
                    message = $"Tag obtenido con exito.",
                }, JsonRequestBehavior.AllowGet);
        }



    }
}
