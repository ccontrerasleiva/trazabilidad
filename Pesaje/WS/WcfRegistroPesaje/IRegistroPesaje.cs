using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace WcfRegistroPesaje
{
  
    [ServiceContract]
    public interface IRegistroPesaje
    {

      
        [OperationContract]
        Resultado WS_REGISTRO_PESAJE(Cabecera c);

      
    }


   
}
