//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfArmado
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class IG_Armado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IG_Armado()
        {
            this.IG_Mov_Armado = new HashSet<IG_Mov_Armado>();
        }

        public int IdIGArmado { get; set; }

        [JsonProperty("stop-time")]
        public string stop_time { get; set; }

        [JsonProperty("stop-event")]
        public string stop_event { get; set; }

        [JsonProperty("start-time")]
        public string start_time { get; set; }

        [JsonProperty("start-event")]
        public string start_event { get; set; }
        public string condition { get; set; }
        public string locationId { get; set; }

        [JsonProperty("tag-count")]
        public string tag_count { get; set; }
        public string type { get; set; }
        public string objectId { get; set; }

        [JsonProperty("driver")]
        public string drivers { get; set; }
        public string status { get; set; }
        public string timestamp { get; set; }
        public string UUID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonProperty("children")]
        public virtual ICollection<IG_Mov_Armado> IG_Mov_Armado { get; set; }
    }
}