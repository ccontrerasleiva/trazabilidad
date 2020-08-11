using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Trazabilidad.Controllers
{
    public class HistorialActivoController : Controller
    {
         
        
        // GET: HistorialActivo
        public ActionResult Index()
        {
            return View();
        }

        #region "respaldo"
        //[HttpPost]
        //public ActionResult Index(FormCollection coleccion)
        //{
        //    List<ViewModels.Custom.HistoricoPatente> hp = new List<ViewModels.Custom.HistoricoPatente>();
        //    try
        //    {
        //        //********************************************

        //        var db = new Data.ProyectoGestionContext();
        //        //var test = new ViewModels.Custom.GestionDiaria.CTren();
        //        using (var conection = db.Database.Connection)
        //        {
        //            conection.Open();
        //            var command = conection.CreateCommand();
        //            string fec1 = coleccion.Get("dtmDate1");
        //            string fec2 = coleccion.Get("dtmDate2");
        //            if (fec1 != "")
        //            {
        //                fec1 = fec1.Split('-')[2] + fec1.Split('-')[1] + fec1.Split('-')[0];
        //                fec2 = fec2.Split('-')[2] + fec2.Split('-')[1] + fec2.Split('-')[0];
        //            }
        //            command.CommandText = " EXEC [dbo].[SP_HISTORIAL_ACTIVO] '" + coleccion["Patente"].ToString() +"','" + fec1 + "','" + fec2 + "'";
        //            using (var reader = command.ExecuteReader())
        //            {
        //                var uHistorico =
        //                    ((IObjectContextAdapter)db)
        //                       .ObjectContext
        //                       .Translate<ViewModels.Custom.HistoricoPatente>(reader)
        //                       .ToList();

        //                //ViewBag.Locomotoras = new SelectList(loco2, "Id", "Description");

        //                //return uHistorico;
        //                return View("List", uHistorico);
        //            }

        //        }

        //        //********************************************
        //        //return x;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }



        //    //Persona per = m.Retornar(int.Parse(coleccion["Codigo"].ToString()));
        //    //if (per != null)
        //    //    return View("EditarPersona", per);
        //    //else
        //    //    return RedirectToAction("Index");
        //}
        #endregion

        [HttpPost]
        //public JsonResult GetActivosList(DateTime FechaDesde, DateTime FechaHasta, string Patente)
        public JsonResult GetActivosList(string  FechaDesde, string FechaHasta, string Patente)
        {
            List<ViewModels.Custom.HistoricoPatente> hp = new List<ViewModels.Custom.HistoricoPatente>();
            try
            {
                //********************************************

                var db = new Data.ProyectoGestionContext();
                //var test = new ViewModels.Custom.GestionDiaria.CTren();
                using (var conection = db.Database.Connection)
                {
                    conection.Open();
                    var command = conection.CreateCommand();
                    string fec1 = FechaDesde.ToString(); // coleccion.Get("dtmDate1");
                    string fec2 = FechaHasta.ToString(); // coleccion.Get("dtmDate2");
                    if (fec1 != "")
                    {
                        fec1 = fec1.Substring(0, 10);
                        fec2 = fec2.Substring(0, 10);
                        fec1 = fec1.Split('-')[2] + fec1.Split('-')[1] + fec1.Split('-')[0];
                        fec2 = fec2.Split('-')[2] + fec2.Split('-')[1] + fec2.Split('-')[0];
                    }
                    command.CommandText = " EXEC [dbo].[SP_HISTORIAL_ACTIVO] '" + Patente + "','" + fec1 + "','" + fec2 + "'";
                    using (var reader = command.ExecuteReader())
                    {
                        var uHistorico =
                            ((IObjectContextAdapter)db)
                               .ObjectContext
                               .Translate<ViewModels.Custom.HistoricoPatente>(reader)
                               .ToList();

                        //ViewBag.Locomotoras = new SelectList(loco2, "Id", "Description");

                        //return uHistorico;
                        return Json(uHistorico);
                    }
                  
                }

                //********************************************
                //return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }



            //Persona per = m.Retornar(int.Parse(coleccion["Codigo"].ToString()));
            //if (per != null)
            //    return View("EditarPersona", per);
            //else
            //    return RedirectToAction("Index");
        }


        [HttpGet]
        public JsonResult Totales_GraficoCharte(FormCollection coleccion)
        {
            //********************************************
            List<ViewModels.Custom.TotalGraficoCharte> lstTotalGrafico = new List<ViewModels.Custom.TotalGraficoCharte>();
            string patente = coleccion.Get("Patente");
         
            var db = new Data.ProyectoGestionContext();
            //var test = new ViewModels.Custom.GestionDiaria.CTren();
            using (var conection = db.Database.Connection)
            {
                conection.Open();
                var command = conection.CreateCommand();
                string fec1 = coleccion.Get("dtmDate1");
                string fec2 = coleccion.Get("dtmDate2");
                if (fec1 != "" && fec1!=null)
                {
                    fec1 = fec1.Split('-')[2] + fec1.Split('-')[1] + fec1.Split('-')[0];
                }

                if (fec2 != "" && fec2 != null)
                {
                    fec2 = fec2.Split('-')[2] + fec2.Split('-')[1] + fec2.Split('-')[0];
                }
                command.CommandText = " EXEC [dbo].[SP_HISTORIAL_ACTIVO] '" + patente +  "','" + fec1 + "','" + fec2 + "'";
                using (var reader = command.ExecuteReader())
                {
                    reader.NextResult();
                    var uTotal =
                        ((IObjectContextAdapter)db)
                           .ObjectContext
                           .Translate<ViewModels.Custom.TotalGraficoCharte>(reader)
                           .ToList();

                    //ViewBag.Locomotoras = new SelectList(loco2, "Id", "Description");

                    //return uHistorico;
                    //return View("List", uHistorico);
                    lstTotalGrafico = uTotal;
                }

            }

            //********************************************

            try
            {
                return Json(lstTotalGrafico, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                throw new Exception(" Se produjo error en el Json", ex);
            }
        }

    }
}