using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfRegistroPesaje
{
    [DataContract]
    public class Cabecera
    {
        //[DataMember]
        //public int IdEtPesajeCabecera { get; set; }

        [DataMember]
        public int CnvBseCod { get; set; }

        [DataMember]
        public int CnvBasCod { get; set; }

        [DataMember]
        public string CnvID { get; set; }
        [DataMember]
        public int CnvPesId { get; set; }


        [DataMember]
        public List<Detalle> Detalles;

        [DataMember]
        public List<Sello> Sellos;

    }
}