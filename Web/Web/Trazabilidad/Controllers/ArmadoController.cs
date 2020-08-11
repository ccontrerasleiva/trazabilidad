namespace Armado.Controllers
{
    using Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ViewModels.Models;
    using ViewModels.Custom;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Web;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.OpenIdConnect;
    using System.Configuration;
    using System.Net.Http;
    using Newtonsoft.Json.Linq;
    using System.Text;
    using System.Linq;

    //[Authorize]

    public class ArmadoController : Controller
    {
        private IHistoriialActivoService _ArmadoService;
        private ITrazaUbicacionContenedorService _TrazaUbicacionContenedorService;
        private ITrazaUbicacionCarroService _TrazaUbicacionCarroService;
        private ITrazaUbicacionLocomotoraService _TrazaUbicacionLocomotoraService;



        public DateTime UnixTimeToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


        #region Constructor

        public ArmadoController(IHistoriialActivoService ArmadoSrvc, ITrazaUbicacionContenedorService UbicacionContenedor,
                                                            ITrazaUbicacionCarroService UbicacionCarros,
                                                            ITrazaUbicacionLocomotoraService UbicacionLocomotora)
        {
            _ArmadoService = ArmadoSrvc;
            _TrazaUbicacionContenedorService = UbicacionContenedor;
            _TrazaUbicacionCarroService = UbicacionCarros;
            _TrazaUbicacionLocomotoraService = UbicacionLocomotora;
        }

        #endregion Constructor


        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" },
      OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
            return View();
            //return PartialView("~/Views");
        }

        public ActionResult ListResumenArmado()
        {
            //ViewBag.estaciones = this.GetStations();
            try
            {
                return View(_ArmadoService.GetViewModelList());
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo error en ListResumenArmado() ", ex);
            }

        }



        [HttpGet]
        //public JsonResult ActivosUpdateforMap()
        public JsonResult ActivosforMap()
        {
            List<TrainActivo> lstResumenArmado = new List<TrainActivo>();

            //var _Armado = _ArmadoService.ActivosUpdateforMap();
            var _Armado = _TrazaUbicacionContenedorService.ActivosforMap();
            //var _Armado2 = _TrazaUbicacionCarroService.ActivosforMap();
            //var _Armado3 = _TrazaUbicacionLocomotoraService.ActivosforMap();
            try
            {
                foreach (var item in _Armado)
                {
                    TrainActivo det = new TrainActivo();
                    
                    det = item;
                    lstResumenArmado.Add(det);
                }

             
                return Json(lstResumenArmado, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                throw new Exception(" Se produjo error en el Json", ex);
            }
        }

       


        [HttpGet]
        public JsonResult ResumenArmado()
        {
            List<ResumenArmado> lstResumenArmado= new List<ResumenArmado>();
            //int totLocomotora = 0;
            //int totCarro = 0;
            //int contLocomotora = 0;
            //int contCarro = 0;
            string strId = "";
            string strStop_time ;
            string strStop_event ;
            string strStart_time;
            string strStar_event;
            string strCondition;
            string strLocationId;
            string strTag_count;
            string strType;
            string strObjectId;
            string strDrivers;
            string strStatus;
            string strTimestamp;
            string strUUID;
            string strFecha;

            Boolean det;

            NumberFormatInfo nfi = new CultureInfo("es-CL", false).NumberFormat;
            nfi.NumberDecimalDigits = 0;

            var _Armado = _ArmadoService.GetViewModelList();

            

            foreach(var item in _Armado)
            {
                //List<Armado> ar = new List<Armado>(_Armado);
               

                strId = item.Id.ToString();
                strStop_time = item.stop_time;
                strStop_event = item.stop_event;
                strStart_time = item.start_time;
                strStar_event = item.start_event;
                strCondition = item.condition;
                strLocationId = item.locationId;
                strTag_count = item.tag_count;
                strType = item.type;
                strObjectId = item.objectId;
                strDrivers = item.drivers;
                strStatus = item.status;
                strTimestamp = item.timestamp;
                strUUID = item.UUID;
                strFecha = item.Fecha.ToString("dd/MM/yyyy hh:mm:ss");
                det = true;
                List<MovArmado> mov = new List<MovArmado>(item.ArmadoMovimiento);
                int con;
                foreach (var item_mov in mov)
                {
                    ResumenArmado objResumen = new ResumenArmado();
                    objResumen.Id = strId;
                    objResumen.stop_time =  UnixTimeToDateTime(Convert.ToDouble(strStop_time.Substring(0,10))).ToString("dd/MM/yyyy hh:mm:ss");
                    objResumen.stop_event = strStop_event;
                    objResumen.start_time = UnixTimeToDateTime(Convert.ToDouble(strStart_time.Substring(0, 10))).ToString("dd/MM/yyyy hh:mm:ss"); 
                    objResumen.star_event = strStar_event;
                    objResumen.condition = strCondition;
                    objResumen.locationId = strLocationId;
                    objResumen.tag_count = strTag_count;
                    objResumen.type = strType;
                    objResumen.objectId = strObjectId;
                    objResumen.drivers = strDrivers;
                    objResumen.status = strStatus;
                    objResumen.timestamp = strTimestamp;
                    objResumen.UUID = strUUID;
                    objResumen.Fecha = strFecha;

                    objResumen.last_read = item_mov.last_read;
                    objResumen.observationUUID = item_mov.observationUUID;
                    objResumen.locationId2 = item_mov.locationId;
                    objResumen.reads = item_mov.reads;
                    objResumen.companyPrefix = item_mov.companyPrefix;
                    objResumen.itemReference = item_mov.itemReference;
                    objResumen.filterValue = item_mov.filterValue;
                    objResumen.serialNumber = item_mov.serialNumber;
                    objResumen.first_read = item_mov.first_read;
                    objResumen.type2 = item_mov.type;
                    objResumen.objectId2 = item_mov.objectId;
                    objResumen.timestamp2 = item_mov.timestamp;
                    objResumen.UUID2 = item_mov.UUID;
                    lstResumenArmado.Add(objResumen);
                    det = false;
                }
                //if(det)
                //    lstResumenArmado.Add(objResumen);

                //objResumen.last_read = item.la

            }
            //    { lstResumenTrazabilidad.Add(ResTrazabilidad); }
            


            try
            {
                return Json(lstResumenArmado, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                throw new Exception(" Se produjo error en el Json", ex);
            }

        }

        private string GetTokenTelemetrica() {
            var Token = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["base_url"]);
                var dict = new Dictionary<string, string>
                {
                    { "grant_type", "password" },
                    { "userName",  ConfigurationManager.AppSettings["user"]},
                    { "password", ConfigurationManager.AppSettings["passwd"] }
                };
                
                using (HttpResponseMessage response = client.PostAsync("Token", new FormUrlEncodedContent(dict)).Result) {
                    using (HttpContent content = response.Content)
                    {
                        Token = JObject.Parse(content.ReadAsStringAsync().Result)["access_token"].ToString();
                    }
                }
            }
            return Token;
        }
        

        [HttpPost]
        public string GetInfoCarros(string locomotora)
        {
            var dt = _ArmadoService.GetContenedoresArmado(locomotora);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }

        [HttpGet]
        public string GetInfoLocomotoras() {
            var dt = _ArmadoService.GetLocomotorasDia();
            var Locomotoras  = "" ;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["base_url"]);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetTokenTelemetrica());
                var loco = new Dictionary<string, string>
                {
                    { "Locs", string.Join(";", dt.Rows.OfType<System.Data.DataRow>().Select(r => r[0].ToString())) }
                };

                HttpContent c = new StringContent(JsonConvert.SerializeObject(loco), Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = client.PostAsync("api/Consultas/GetFepVigentes", c).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        Locomotoras = content.ReadAsStringAsync().Result;
                    }
                }
            }
            return Locomotoras;
        }


        [HttpGet]
        public string CantidadActivosforMap()
        {
            try
            {
                var datos = _ArmadoService.GetViewCantidadActivosList();
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(datos);
                return JSONString;
            }
            catch (System.Exception ex)
            {
                throw new Exception(" Se produjo error en el Json", ex);
            }
        }

    }

  

}