using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfArmado
{
    [DataContract]
    public class clsIgMovArmado
    {
        public int IdIGArmado { get; set; }

        [DataMember]
        public string last_read { get; set; }

        [DataMember]
        public  string observationUUID { get; set; }

        [DataMember]
        public string locationId { get; set; }

        [DataMember]
        public string reads { get; set; }

        [DataMember]
        public string companyPrefix { get; set; }

        [DataMember]
        public string itemReference { get; set; }

        [DataMember]
        public string filterValue { get; set; }

        [DataMember]
        public string serialNumber { get; set; }

        [DataMember]
        public string first_read { get; set; }

        [DataMember]
        public string type { get; set; }

        [DataMember]
        public string UUID { get; set; }

        [DataMember]
        public string objectId { get; set; }

        [DataMember]
        public string timestamp { get; set; }
    }
}