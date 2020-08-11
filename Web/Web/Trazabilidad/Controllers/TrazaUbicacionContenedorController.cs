namespace TrazaUbicacionContenedor.Controllers
{
    using Trazabilidad.Helpers;
    using Resources.Exceptions;
    using Resources.Strings;
    using Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using ViewModels.Enum;
    using ViewModels.Models;
    using ViewModels.Custom;
    using Newtonsoft.Json;
    using System.Timers;
    using System.Globalization;

    //[Authorize]

    public class TrazaUbicacionContenedorController : Controller
    {
        private ITrazaUbicacionContenedorService _TrazaUbicacionContenedorService;



        public DateTime UnixTimeToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


        #region Constructor

        public TrazaUbicacionContenedorController(ITrazaUbicacionContenedorService UbicacionContenedor)
        {
            _TrazaUbicacionContenedorService = UbicacionContenedor;
        }

        #endregion Constructor


        public ActionResult Index()
        {
            return View();
            //return PartialView("~/Views");
        }

        //public ActionResult ListResumenArmado()
        //{
        //    //ViewBag.estaciones = this.GetStations();
        //    try
        //    {
        //        return View(_ArmadoService.GetViewModelList());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Se produjo error en ListResumenArmado() ", ex);
        //    }

        //}

        
        //public JsonResult ListActivos()
        //{
        //    List<ResumenActivo> lstResumenArmado = new List<ResumenActivo>();
        //    //ViewBag.estaciones = this.GetStations();
        //    try
        //    {
        //        //return View(_TrazaUbicacionContenedorService.ActivosListado());
        //        return Json(lstResumenArmado, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Se produjo error en ListResumenActivos() ", ex);
        //    }

        //}

        public ActionResult ListActivos()
        {
            //ViewBag.estaciones = this.GetStations();
            try
            {
                return View(_TrazaUbicacionContenedorService.GetViewModelList());
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo error en ListResumenArmado() ", ex);
            }

        }


        [HttpGet]
        public JsonResult ResumenActivos()
        {
            List<ResumenActivo> lstResumenActivo = new List<ResumenActivo>();
            // esto es para los decimales de los numeros.
            NumberFormatInfo nfi = new CultureInfo("es-CL", false).NumberFormat;
            nfi.NumberDecimalDigits = 0;
            var _Activo = _TrazaUbicacionContenedorService.ActivosListado();

            foreach (var item in _Activo)
            {
                ResumenActivo objResumen = new ResumenActivo();
                objResumen.Orden = item.Orden;
                objResumen.IdContenedor = item.IdContenedor;
                objResumen.Patente = item.Patente;
                objResumen.IdRuta = item.IdRuta;
                objResumen.Descripcion_Ruta = item.Descripcion_Ruta;
                objResumen.Sigla_Codelco = item.Sigla_Codelco;
                objResumen.Tiempo = item.Tiempo;
                objResumen.Descripcion = item.Descripcion;
                objResumen.Trocha = item.Trocha;
                //objResumen.Fecha_Actualizacion = UnixTimeToDateTime(Convert.ToDouble(item.Fecha_Actualizacion.Substring(0, 10))).ToString("dd/MM/yyyy hh:mm:ss");
                objResumen.Fecha_Actualizacion = item.Fecha_Actualizacion.ToString();   // ("dd/MM/yyyy hh:mm:ss");
                lstResumenActivo.Add(objResumen);

            }

            try
            {
                //int b = 0;
                //double a = (1 / b);
                return Json(lstResumenActivo, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                throw new Exception(" Se produjo error en el Json", ex);
            }
        }


            //[HttpGet]
            //public JsonResult ListActivos()
            //{
            //    List<ResumenActivo> lstActivo = new List<ResumenActivo>();

            //    // esto es para los decimales de los numeros.
            //    NumberFormatInfo nfi = new CultureInfo("es-CL", false).NumberFormat;
            //    nfi.NumberDecimalDigits = 0;
            //    var _Activo = _TrazaUbicacionContenedorService.ActivosListado();

            //    foreach (var item in _Activo)
            //    {

            //            ResumenActivo objResumen = new ResumenActivo();

            //            objResumen.IdContenedor = item.IdContenedor;
            //            objResumen.Patente = item.Patente;
            //            objResumen.IdRuta = item.IdRuta;
            //            objResumen.Descripcion_Ruta = item.Descripcion_Ruta;
            //            objResumen.Sigla_Codelco = item.Sigla_Codelco;
            //            //objResumen.Fecha_Actualizacion = UnixTimeToDateTime(Convert.ToDouble(item.Fecha_Actualizacion.Substring(0, 10))).ToString("dd/MM/yyyy hh:mm:ss");
            //            objResumen.Fecha_Actualizacion = item.Fecha_Actualizacion.ToString();   // ("dd/MM/yyyy hh:mm:ss");
            //        lstActivo.Add(objResumen);

            //    }

            //    try
            //    {
            //        return Json(lstActivo, JsonRequestBehavior.AllowGet);
            //    }
            //    catch (System.Exception ex)
            //    {
            //        throw new Exception(" Se produjo error en el Json", ex);
            //    }

            //}







        }

  

}