using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Custom
{
    public class TrainActivo
    {
        public int id { get;set; }
        public string Patente { get; set; }
        public string location { get; set; }
        public string activo { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Trocha { get; set; }
        public int Orden { get; set; }
    }
}
