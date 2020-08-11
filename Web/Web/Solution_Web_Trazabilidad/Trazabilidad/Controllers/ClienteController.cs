namespace Trazabilidad.Controllers
{
    using Trazabilidad.Helpers;
    using Resources.Strings;
    using Services.Interfaces;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    //[Authorize]

    public class ClienteController : Controller
    {
        private IClienteService _ClienteService;

        #region Constructor

        public ClienteController(IClienteService ClienteSrvc)
        {
            _ClienteService = ClienteSrvc;
        }

        #endregion Constructor

        [HttpGet]
        public ActionResult List()
        {
            //ViewBag.ClienteType = this.GetTypeCliente();
            return View(_ClienteService.GetViewModelList());
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
        public ActionResult Edit(ViewModels.Models.Cliente Clientemom)
        {
            try
            {
                _ClienteService.Edit(Clientemom);

                return Json(
                        new
                        {
                            success = true,
                            source = Models.Cliente,
                            message = $"Cliente modificada con éxito.",
                        });
            }
            catch (System.Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        source = Resources.Strings.Models.Cliente,
                        message = $"{Errors.UnknownError} {Errors.ErrorNotified}"
                    });
            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        } 

        [HttpPost]
        public async Task<ActionResult> Create(ViewModels.Models.Cliente vCliente)
        {
            //TODO: Test this *revisar bien*
            if (!ModelState.IsValid)
            {
                return PartialView("~/Views/Cliente/Partial/_Create", vCliente);
            }

            await _ClienteService.Save(vCliente);

            return Json(
                    new
                    {
                        success = true,
                        source = Resources.Strings.Models.Cliente,
                        message = $"Cliente {vCliente.Id} creado con éxito.",
                        data = this.RenderRazorViewToString("Partial/_Cliente", vCliente)
                    });
        }
        // GET: Cliente/Edit/5

        public ActionResult LoadClienteModal(int id)
        {
            var ptt = _ClienteService.GetByIdVM(id);

            return Json(
                new
                {
                    success = true,
                    data = this.RenderRazorViewToString("Partial/_Edit", ptt),
                    source = Models.Cliente,
                    message = $"Cliente obtenida con exito.",
                }, JsonRequestBehavior.AllowGet);
        }
       
        

       
    }
}