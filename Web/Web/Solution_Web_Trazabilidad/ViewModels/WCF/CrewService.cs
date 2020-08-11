using System;
using System.Runtime.Serialization;

namespace ViewModels.WCF
{
    [DataContract(IsReference = true)]
    public class CrewService
    {
        [DataMember]
        public string ServiceCode { get; set; }

        [DataMember]
        public string OriginCode { get; set; }

        [DataMember]
        public string OriginName { get; set; }

        [DataMember]
        public string DestinationName { get; set; }

        [DataMember]
        public string DestinationCode { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public DateTime EndTime { get; set; }

        [DataMember]
        public int TrainId { get; set; }

        [DataMember]
        public string AzureID { get; set; }

        [DataMember]
        public string AccompaniantAzureID { get; set; }

        [DataMember]
        public string AccompaniantRol { get; set; }

        [DataMember]
        public int Id_Actividad { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public bool Iniciado { get; set; }

        [DataMember]
        public int Id_Jornada { get; set; }
    }
}