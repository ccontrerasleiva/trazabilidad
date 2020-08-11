using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Custom
{
    public class ResumenActivo
    {
        public string IdContenedor { get; set; }
        public string Patente { get; set; }
        public string IdRuta {get;set;}
        public string Descripcion_Ruta { get; set; }
        public string Sigla_Codelco { get; set; }
        public string Fecha_Actualizacion{ get; set; }
                public int Tiempo { get; set; }
        public string Descripcion { get; set; }
        public string Trocha { get; set; }
        public int Orden { get; set; }

    }
}
