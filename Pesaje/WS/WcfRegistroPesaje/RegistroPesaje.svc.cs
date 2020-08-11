using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity.Core.Objects;
using System.Xml.Serialization;
using System.IO;

namespace WcfRegistroPesaje
{
    public class RegistroPesaje : IRegistroPesaje
    {


        public Resultado WS_REGISTRO_PESAJE(Cabecera c)
        {
            StringWriter stringwriter = new StringWriter();
            string strXml = "";
            XmlSerializer x = new XmlSerializer(c.GetType());
            x.Serialize(stringwriter, c);
            strXml = stringwriter.ToString();
            TrazabilidadDBEntities Contex = new TrazabilidadDBEntities();
            TrazabilidadDBEnti_LOg CLog = new TrazabilidadDBEnti_LOg();
            try
            {
                

                ET_Pesaje_Cabecera cc = new ET_Pesaje_Cabecera();
                cc.CnvBseCod = c.CnvBseCod;
                cc.CnvBasCod = c.CnvBasCod;
                cc.CnvID = c.CnvID;
                cc.CnvPesId = c.CnvPesId;
                Contex.ET_Pesaje_Cabecera.Add(cc);

                foreach (var cd in c.Detalles)
                {
                    ET_Pesaje_Detalle cc_d = new ET_Pesaje_Detalle();
                    cc_d.IdEtPesajeCabecera = cc.IdEtPesajeCabecera;
                    cc_d.PesNro = cd.PesNro;
                    cc_d.PesCarIde = cd.PesCarIde;
                    cc_d.PesConId = cd.PesConId;
                    cc_d.PesComFec = cd.PesComFec;
                    cc_d.PesTarFec = cd.PesTarFec;
                    cc_d.PesComBrut = cd.PesComBrut;
                    cc_d.PesComNet = cd.PesComNet;
                    cc_d.PesTar = cd.PesTar;
                    cc_d.PesConSelPor = cd.PesConSelPor;
                    Contex.ET_Pesaje_Detalle.Add(cc_d);
                }

                foreach (var sell in c.Sellos)
                {
                    ET_Pesaje_Sello sell_d = new ET_Pesaje_Sello();
                    sell_d.CnvIdSello = sell.CnvIdSello;
                    sell_d.CnvSelloIni = sell.CnvSelloIni;
                    sell_d.CnvSelloFin = sell.CnvSelloFin;
                    sell_d.CnvSelloEstado = sell.CnvSelloEstado;
                    Contex.ET_Pesaje_Sello.Add(sell_d);
                }

                Contex.SaveChanges();

                Resultado objResultado = new Resultado();
                objResultado.Status = "OK";
                objResultado.Mensaje = "";

                ET_Pesaje_Log Logs = new ET_Pesaje_Log();
                Logs.Texto = strXml;
                Logs.Estado = "OK";
                Logs.Descripcion_Estado = "";
                CLog.ET_Pesaje_Log.Add(Logs);
                CLog.SaveChanges();

                return objResultado;


            }
            catch(Exception ex)
            {
                ET_Pesaje_Log Logs = new ET_Pesaje_Log();
                Logs.Texto = strXml;
                Logs.Estado = "NOK";
                Logs.Descripcion_Estado = ex.Message;
                CLog.ET_Pesaje_Log.Add(Logs);
                CLog.SaveChanges();

                Resultado objResultado = new Resultado();
                objResultado.Status = "NOK";
                objResultado.Mensaje = ex.Message;
                return objResultado;
            }
          
        }

      

    }

 

}
