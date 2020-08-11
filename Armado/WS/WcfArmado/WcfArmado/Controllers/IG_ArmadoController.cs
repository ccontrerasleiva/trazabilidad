using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description; 

namespace WcfArmado
{
    public class IG_ArmadoController : ApiController
    {
        private TrazabilidadDBEntities db = new TrazabilidadDBEntities();
        private TrazabilidadDBEntities db_IL = new TrazabilidadDBEntities();

        // GET: api/IG_Armado
        //public IQueryable<IG_Armado> GetIG_Armado()
        //{
        //    return db.IG_Armado;
        //}

        // GET: api/IG_Armado/5
        //[ResponseType(typeof(IG_Armado))]
        //public IHttpActionResult GetIG_Armado(int id)
        //{
        //    IG_Armado iG_Armado = db.IG_Armado.Find(id);
        //    if (iG_Armado == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(iG_Armado);
        //}

        // PUT: api/IG_Armado/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutIG_Armado(int id, IG_Armado iG_Armado)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != iG_Armado.IdIGArmado)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(iG_Armado).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!IG_ArmadoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/IG_Armado
        [ResponseType(typeof(IG_Armado))]


        public Resultado PostIG_Armado(IG_Armado iG_Armado)
        { 
        //public string Post([FromBody]string par)
        //{
        //    string seperator = ",";
        //    string data = string.Join(seperator, par);
        //    string result = string.Format("Succesfully uploaded: {0}", data);
        //    return result;

            var contenido = Request.Content.Headers.ContentType;

        var ObjRescato = iG_Armado;
        IG_Log_Armado ILog = new IG_Log_Armado();
        var xjson = JsonConvert.SerializeObject(ObjRescato);
        //var xjson = JsonConvert.SerializeObject(List<IG_Armado>);

        ILog.Texto = xjson;


            Resultado res = new Resultado();
            try
            {
                if (!ModelState.IsValid)
                {
                    res.Status = "NOK";
                    res.Mensaje = "Información Invalidad - " + contenido.ToString();
                    ILog.Estado = "NOK";
                    ILog.Texto = "Información Invalidad - " + contenido.ToString();
                    var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                                      .Select(x => new { x.Key, x.Value.Errors })
                                      .ToArray();


        ILog.Descripcion_Estado = errors[0].Errors[0].Exception.ToString();  //errors[0].Key.ToString(); //"Información Invalidad";
                    db_IL.IG_Log_Armado.Add(ILog);
                    db_IL.SaveChanges();

                    return res;
                    //return BadRequest(ModelState);
                }

    db.IG_Armado.Add(iG_Armado);
                db.SaveChanges();
                res.Status = "OK";
                res.Mensaje = "";

                ILog.Estado = "OK";
                ILog.Descripcion_Estado = "";
                db_IL.IG_Log_Armado.Add(ILog);
                db_IL.SaveChanges();

                return res;
                //return CreatedAtRoute("DefaultApi", new { id = iG_Armado.IdIGArmado }, iG_Armado);
            }
            catch (Exception ex)
            {
                res.Status = "NOK";
                res.Mensaje = ex.Message;

                ILog.Estado = "NOK";
                ILog.Texto = "Se produjo error";
                ILog.Descripcion_Estado = ex.Message;
                db_IL.IG_Log_Armado.Add(ILog);
                db_IL.SaveChanges();

                return res;
            }
        }

        // DELETE: api/IG_Armado/5
        //[ResponseType(typeof(IG_Armado))]
        //public IHttpActionResult DeleteIG_Armado(int id)
        //{
        //    IG_Armado iG_Armado = db.IG_Armado.Find(id);
        //    if (iG_Armado == null)
        //    {
        //        return NotFound();
        //    }

        //    db.IG_Armado.Remove(iG_Armado);
        //    db.SaveChanges();

        //    return Ok(iG_Armado);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool IG_ArmadoExists(int id)
        //{
        //    return db.IG_Armado.Count(e => e.IdIGArmado == id) > 0;
        //}
    }
}