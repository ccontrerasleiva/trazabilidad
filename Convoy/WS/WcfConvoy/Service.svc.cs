using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using WcfConvoy.ws_Convoy;

namespace WcfConvoy
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService

    {
        public SDT_Registro_ConvoyPesCarItem[] PescarItem { get; private set; }

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
        TrazabilidadEntities Contex = new TrazabilidadEntities();
        TrazabilidadEntities_Log Contex2 = new TrazabilidadEntities_Log();
        TrazabilidadEntitiesProcedimiento Procedi = new TrazabilidadEntitiesProcedimiento();

        ws_Convoy.WSEtruckTrenes obj_Xml = new ws_Convoy.WSEtruckTrenes();
        ws_Convoy.Respuesta rest = new ws_Convoy.Respuesta();


        public string ProcesarTrazabilidad()
        {
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
            //SqlCommand da = new SqlCommand("sp_id_alty", conn);
            //da.CommandType = System.Data.CommandType.StoredProcedure;
            ////da.Parameters.Add("@id_alt", SqlDbType.NVarChar).Value = id_alt;
            //conn.Open();
            //da.ExecuteNonQuery();
            //conn.Close();
            //return "";
            try
            {

                var sP_Armado_Results = Procedi.SP_Armado();
                //.SP_Armado. <SP_Armado_Result>("SP_Armado");


                //Procedi.SP_Armado();
                return "";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }


        public string ProcesarConvoy()
        {
           
            ws_Convoy.Registro_Convoy objReg = new ws_Convoy.Registro_Convoy();
          

            //int cont;
            int xChoId; 

          
            try
            {
                var Convoy = (from cabecera in Contex.ET_Convoy_Cabecera
                              join detalle in Contex.ET_Convoy_Detalle
                              on cabecera.IdEtConvoyCabecera equals detalle.IdEtConvoyCabecera
                              where cabecera.Procesado == false
                              select new
                              {
                                  cabecera.IdEtConvoyCabecera,
                                  cabecera.CnvBseCod,
                                  cabecera.CnvBasCod,
                                  cabecera.CnvID,
                                  cabecera.CnvObs,
                                  cabecera.CnvCicPesCod,
                                  cabecera.CnvChoid,
                                  cabecera.CnvChoNom,
                                  detalle.PesCarIde,
                                  detalle.PesCarDes,
                                  detalle.PesConId,
                                  detalle.PesConDes
                              }).ToList();

                //ws_Convoy.SDT_Registro_ConvoyPesCarItem[] art = new ws_Convoy.SDT_Registro_ConvoyPesCarItem[Convoy.Count];
                List<ws_Convoy.SDT_Registro_ConvoyPesCarItem> art = new List<SDT_Registro_ConvoyPesCarItem>();



                //string[] art = new string[Comboy.Count];
                int auxId = 0;
                for (int cont = 0; cont < Convoy.Count; cont++)
                {
                    xChoId = Convert.ToInt32(Convoy[cont].CnvChoid);
                  
                    auxId= Convert.ToInt32(Convoy[cont].IdEtConvoyCabecera);
                    ws_Convoy.SDT_Registro_ConvoyPesCarItem aa = new ws_Convoy.SDT_Registro_ConvoyPesCarItem();

                    objReg.CnvBseCod = Convert.ToInt16(Convoy[cont].CnvBseCod);
                    objReg.CnvBasCod = Convert.ToInt16(Convoy[cont].CnvBasCod);
                    objReg.CnvID = Convert.ToInt32(Convoy[cont].CnvID);
                    objReg.CnvObs = Convoy[cont].CnvObs.ToString();
                    objReg.CnvCicPesCod = Convert.ToInt16(Convoy[cont].CnvCicPesCod);
                    objReg.CnvChoID = Convert.ToInt32(Convoy[cont].CnvChoid);
                    //objReg.CnvChoDV=
                    objReg.CnvChoNom = Convoy[cont].CnvChoNom.ToString();
                    
                    aa.PesCarIde = Convoy[cont].PesCarIde;
                    aa.PesCarDes = Convoy[cont].PesCarDes;
                    aa.PesConId = Convert.ToInt32(Convoy[cont].PesConId);
                    aa.PesConDes = Convoy[cont].PesConDes;
                    
                        art.Add(aa);
                        objReg.PesCar = art.ToArray();

                    if (cont < Convoy.Count-1)
                    {
                        if (xChoId != Convert.ToInt32(Convoy[cont + 1].CnvChoid))
                        {
                            xChoId = Convert.ToInt32(Convoy[cont + 1].CnvChoid);
                            //rest = obj_Xml.WS_REGISTRO_CONVOY(objReg);
                            rest = Consultar_Etruck(objReg);

                            if (rest.SDTWSRespuesta[0].SDTWSRespuestaId == "ERROR")
                            {
                                //for (int cLog = 0; cLog < rest.SDTWSRespuesta.ToList().Count(); cLog++)
                                //{
                                //    ET_Convoy_Log_Service Log_ = new ET_Convoy_Log_Service();
                                //    Log_.IdEtConvoyCabecera = auxId;
                                //    Log_.Descripcion = rest.SDTWSRespuesta[cLog].SDTWSRespuestaDescripcion;
                                //    Log_.Fecha = DateTime.Today;
                                //    Contex2.ET_Convoy_Log_Service.Add(Log_);

                                //    //Console.WriteLine(rest.SDTWSRespuesta[0].SDTWSRespuestaDescripcion);
                                //}
                                //Contex2.SaveChanges();
                                Grabar_WS(rest, auxId);
                            }

                            else
                            {
                              
                                ET_Convoy_Log_Service Log_ = new ET_Convoy_Log_Service();
                                Log_.IdEtConvoyCabecera = Convoy[cont].IdEtConvoyCabecera;
                                Log_.Descripcion ="OK";
                                Log_.Fecha = DateTime.Today;
                                Contex2.ET_Convoy_Log_Service.Add(Log_);
                                Contex2.SaveChanges();

                                var query = from c in Contex.ET_Convoy_Cabecera
                                            where c.IdEtConvoyCabecera == auxId
                                            select c;
                                foreach (ET_Convoy_Cabecera c in query) c.Procesado = true;
                                Contex.SaveChanges();
                            }

                            //rest = null;
                            //objReg = new ws_Convoy.Registro_Convoy();
                            //ws_Convoy.WSEtruckTrenes obj_Xml = new ws_Convoy.WSEtruckTrenes();
                        }
                    }
                    else
                    {
                        //rest = obj_Xml.WS_REGISTRO_CONVOY(objReg);
                        rest = Consultar_Etruck(objReg);

                        if (rest.SDTWSRespuesta[0].SDTWSRespuestaId == "ERROR")
                        {
                            //for (int cLog = 0; cLog < rest.SDTWSRespuesta.ToList().Count(); cLog++)
                            //{
                            //    ET_Convoy_Log_Service Log_ = new ET_Convoy_Log_Service();
                            //    Log_.IdEtConvoyCabecera = auxId;
                            //    Log_.Descripcion = rest.SDTWSRespuesta[cLog].SDTWSRespuestaDescripcion;
                            //    Log_.Fecha = DateTime.Today;
                            //    Contex2.ET_Convoy_Log_Service.Add(Log_);
                            //}
                            //Contex2.SaveChanges();

                            Grabar_WS(rest, auxId);


                        }
                        else
                        {
                            ET_Convoy_Log_Service Log_ = new ET_Convoy_Log_Service();
                            Log_.IdEtConvoyCabecera = Convoy[cont].IdEtConvoyCabecera;
                            Log_.Descripcion = "OK";
                            Log_.Fecha = DateTime.Today;
                            Contex2.ET_Convoy_Log_Service.Add(Log_);
                            Contex2.SaveChanges();

                            var query = from c in Contex.ET_Convoy_Cabecera
                                        where c.IdEtConvoyCabecera == auxId
                                        select c;
                            foreach (ET_Convoy_Cabecera c in query) c.Procesado = true;
                            Contex.SaveChanges();
                        }
                    }
                }
                return "OK";
            }
            catch(Exception ex)
            {
                return "Error General -> " + ex.Message;
            }


            
        }

        string  Grabar_WS(ws_Convoy.Respuesta objRest, int auxId)
        {
            try
            {
                for (int cLog = 0; cLog < objRest.SDTWSRespuesta.ToList().Count(); cLog++)
                {
                    ET_Convoy_Log_Service Log_ = new ET_Convoy_Log_Service();
                    Log_.IdEtConvoyCabecera = auxId;
                    Log_.Descripcion = objRest.SDTWSRespuesta[cLog].SDTWSRespuestaDescripcion;
                    Log_.Fecha = DateTime.Today;
                    Contex2.ET_Convoy_Log_Service.Add(Log_);

                    //Console.WriteLine(rest.SDTWSRespuesta[0].SDTWSRespuestaDescripcion);
                }
                Contex2.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro servicio -> " + ex.Message);
                //return "Erro servicio -> " + ex.Message;
            }
        }

        ws_Convoy.Respuesta Consultar_Etruck(Registro_Convoy objT)
        {
            try
            {
                
                rest = obj_Xml.WS_REGISTRO_CONVOY(objT);
                return rest;

            }
            catch(Exception ex)
            {
                throw new Exception("Erro consultar Etruck -> " + ex.Message);
                //return null;
            
            }
        }


    }
}
