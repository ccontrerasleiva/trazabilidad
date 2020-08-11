using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfArmado
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IArmadoServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IArmadoServ
    {
        //[OperationContract]
        //Resultado WS_Registro_Armado(clsIgArmado igArmado);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "WS_Registro_Armado")]
        Resultado WS_Registro_Armado(Stream JSONdataStream);
    }
}
