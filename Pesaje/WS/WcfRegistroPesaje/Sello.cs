using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfRegistroPesaje
{
    [DataContract]
    public class Sello
    {
        public int IdEtPesajeCabecera { get; set; }

        [DataMember]
        public int CnvIdSello { get; set; }

        [DataMember]
        public int CnvSelloIni { get; set; }

        [DataMember]
        public int CnvSelloFin { get; set; }

        [DataMember]
        public string CnvSelloEstado { get; set; }

    }
}