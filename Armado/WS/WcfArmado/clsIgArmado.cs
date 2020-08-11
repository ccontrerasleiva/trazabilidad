using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfArmado
{
    [DataContract]
    public class clsIgArmado
    {
        [DataMember]
        public string stop_time { get; set; }

        [DataMember]
        public string stop_event { get; set; }

        [DataMember]
        public string start_time { get; set; }

        [DataMember]
        public string start_event { get; set; }

        [DataMember]
        public string condition { get; set; }
        [DataMember]
        public string locationId { get; set; }
        [DataMember]
        public string tag_count { get; set; }
        [DataMember]
        public string type { get; set; }
        [DataMember]
        public string UUID { get; set; }
        [DataMember]
        public string objectId { get; set; }
        [DataMember]
        public string drivers { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string timestamp { get; set; }
        [DataMember]
        public List<clsIgMovArmado> children;
    }
}