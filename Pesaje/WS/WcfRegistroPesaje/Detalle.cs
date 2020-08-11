using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfRegistroPesaje
{
    [DataContract]
    public class Detalle
    {
        //[DataMember]
        public int IdEtPesajeCabecera { get; set; }
        [DataMember]
        public int PesNro { get; set; }
        [DataMember]
        public string PesCarIde { get; set; }

        [DataMember]
        public int PesConId { get; set; }

        [DataMember]
        public DateTime? PesComFec { get; set; }
        [DataMember]
        public DateTime? PesTarFec { get; set; }
        [DataMember]
        public int PesComBrut { get; set; }
        [DataMember]
        public int PesComNet { get; set; }
        [DataMember]
        public int PesTar { get; set; }
        [DataMember]
        public string PesConSelPor { get; set; }

    }
}