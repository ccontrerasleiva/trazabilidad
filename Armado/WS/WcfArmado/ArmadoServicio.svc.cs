using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace WcfArmado
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ArmadoServicio : IArmadoServ
    {
        public Resultado WS_Registro_Armado(Stream JSONdataStream)
        {
            Resultado result = new Resultado();
            
            try
            {
                TrazabilidadArmadoDBEntities Contex = new TrazabilidadArmadoDBEntities();
                StreamReader reader = new StreamReader(JSONdataStream);

                string JSONdata = reader.ReadToEnd();
                JSONdata = JSONdata.Replace("stop-event", "stop_event");
                JSONdata = JSONdata.Replace("stop-time", "stop_time");
                JSONdata = JSONdata.Replace("start-time", "start_time");
                JSONdata = JSONdata.Replace("start-event", "start_event");
                JSONdata = JSONdata.Replace("tag-count", "tag_count");

                JSONdata = JSONdata.Replace("last-read", "last_read");
                JSONdata = JSONdata.Replace("first-read", "first_read");

                JavaScriptSerializer jss = new JavaScriptSerializer();
                clsIgArmado cust = jss.Deserialize<clsIgArmado>(JSONdata);
                //IG_Mov_Armado cust_mov = jss.Deserialize<IG_Armado>(JSONdataContains<IG_Mov_Armado>);
                if (cust == null)
                {
                    result.Status= "NOK";
                    result.Mensaje = "No se pueden deserializar los datos JSON.";
                    return result;
                }
                //clsIgArmado newCustomer = new  clsIgArmado
                IG_Armado newCustomer = new IG_Armado()
                {

                    stop_event = cust.stop_event,
                    start_time = cust.start_time,
                    type = cust.type,
                    stop_time = cust.stop_time,
                    condition = cust.condition,
                    drivers = cust.drivers,
                    start_event = cust.start_event,
                    locationId = cust.locationId,
                    tag_count = cust.tag_count,
                    UUID = cust.UUID,
                    objectId=cust.objectId,
                    timestamp=cust.timestamp,
                    status=cust.status

                };
                Contex.IG_Armado.Add(newCustomer);


                foreach(var objDetalle in cust.children)
                {
                    //clsIgMovArmado cust_detalle = new clsIgMovArmado();
                    IG_Mov_Armado cust_detalle = new IG_Mov_Armado();
                    cust_detalle.last_read = objDetalle.last_read;
                    cust_detalle.observationUUID = objDetalle.observationUUID;
                    cust_detalle.locationId = objDetalle.locationId;
                    cust_detalle.reads = objDetalle.reads;
                    cust_detalle.first_read = objDetalle.first_read;
                    cust_detalle.type = objDetalle.type;
                    cust_detalle.UUID = objDetalle.UUID;
                    cust_detalle.objectId = objDetalle.objectId;
                    cust_detalle.timestamp = objDetalle.timestamp;
                    Contex.IG_Mov_Armado.Add(cust_detalle);
                }

                Contex.SaveChanges();

                //BDUsuario.Personas.InsertOnSubmit(newCustomer);
                //BDUsuario.SubmitChanges();

                result.Status = "OK";
                result.Mensaje = "";
                return result;
            }
            catch (Exception ex)
            {
                result.Status = "NOK";
                result.Mensaje = ex.Message;
                return result;
            }
        }

        //public Resultado WS_Registro_Armado(clsIgArmado ObjArmado)
        //{
        //    try
        //    {
        //        //TrazabilidadArmadoDBEntities Contex = new TrazabilidadArmadoDBEntities();
        //        ////TrazabilidaIngenovaDBEntities Contex = new TrazabilidaIngenovadDBEntities();
        //        ////clsIgArmado CB = new clsIgArmado();
        //        //IG_Armado CA = new IG_Armado();
        //        //CA.Stop_Time = ObjArmado.Stop_Time;
        //        //CA.Stop_Event = ObjArmado.Stop_Event;
        //        //CA.Start_Time = ObjArmado.Start_Time;
        //        //CA.Start_Event = ObjArmado.Start_Event;
        //        //CA.Condition = ObjArmado.Condition;
        //        //CA.LocationId = ObjArmado.LocationId;
        //        //CA.Tag_Count = ObjArmado.Tag_Count;
        //        //CA.Type = ObjArmado.Type;
        //        //CA.UUID = ObjArmado.UUID;
        //        //CA.ObjectId = ObjArmado.ObjectId;
        //        //CA.Drivers = ObjArmado.Drivers;
        //        //CA.Status = ObjArmado.Status;
        //        //CA.TimeStamp = ObjArmado.TimeStamp;
        //        //Contex.IG_Armado.Add(CA);


        //        //foreach (var Obj_Detalle in ObjArmado.IgMovArmado)
        //        //{
        //        //    IG_Mov_Armado Obj_D = new IG_Mov_Armado();
        //        //    Obj_D.Last_Read = Obj_Detalle.Last_Read;
        //        //    Obj_D.ObservationUUID = Obj_Detalle.ObservationUUID;
        //        //    Obj_D.LocationId = Obj_Detalle.LocationId;
        //        //    Obj_D.Reads = Obj_Detalle.Reads;
        //        //    Obj_D.CompanyPrefix = Obj_Detalle.CompanyPrefix;
        //        //    Obj_D.ItemReference = Obj_Detalle.ItemReference;
        //        //    Obj_D.FilterValue = Obj_Detalle.FilterValue;
        //        //    Obj_D.SerialNumber = Obj_Detalle.SerialNumber;
        //        //    Obj_D.First_Read = Obj_Detalle.First_Read;
        //        //    Obj_D.Type = Obj_Detalle.Type;
        //        //    Obj_D.UUID = Obj_Detalle.UUID;
        //        //    Obj_D.ObjectId = Obj_Detalle.ObjectId;
        //        //    Obj_D.TimeStamp = Obj_Detalle.TimeStamp;
        //        //    Contex.IG_Mov_Armado.Add(Obj_D);
        //        //}

        //        //Contex.SaveChanges();

        //        Resultado ObjResultado = new Resultado();
        //        ObjResultado.Status = "OK";
        //        ObjResultado.Mensaje = "";
        //        return ObjResultado;


        //    }
        //    catch (Exception ex)
        //    {
        //        Resultado ObjResultado = new Resultado();
        //        ObjResultado.Status = "NOK";
        //        ObjResultado.Mensaje = ex.Message;
        //        return ObjResultado;

        //    }
        //}
    }
}

