using System.Collections.Generic;

namespace ViewModels.WCF
{
    public class WCFEstacion : WCFBaseModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Active { get; set; } = true;
        public string Code { get; set; }
        public string Name { get; set; }
        public int PK { get; set; }

        //TODO: Change to object/enum
        public int Type { get; set; }

        public string Area { get; set; }

        #region Collections

        public ICollection<WCFRoute> RouteOrigins { get; set; }
        public ICollection<WCFRoute> RouteDestinations { get; set; }

        #endregion Collections
    }
}