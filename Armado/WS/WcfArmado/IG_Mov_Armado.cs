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
    using System;
    using System.Collections.Generic;
    
    public partial class IG_Mov_Armado
    {
        public int IdIG_Mov_Armado { get; set; }
        public int IdIGArmado { get; set; }
        public string last_read { get; set; }
        public string observationUUID { get; set; }
        public string locationId { get; set; }
        public string reads { get; set; }
        public string companyPrefix { get; set; }
        public string itemReference { get; set; }
        public string filterValue { get; set; }
        public string serialNumber { get; set; }
        public string first_read { get; set; }
        public string type { get; set; }
        public string UUID { get; set; }
        public string objectId { get; set; }
        public string timestamp { get; set; }
    
        public virtual IG_Armado IG_Armado { get; set; }
    }
}
