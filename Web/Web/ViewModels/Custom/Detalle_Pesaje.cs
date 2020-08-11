using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Custom
{
    public class Detalle_Pesaje
    {
        public int IdTrazabilidad { get; set; }
        public int IdTrazabilidadMovCarro { get; set; }
        public string Carro_Patente { get; set; }
        public string Ubicacion_carro { get; set; }
        public string Contenedor_Patente { get; set; }
        public string Ubicacion_Contenedor { get; set; }
        public int PesoTara { get; set; }
        public int PesoNeto { get; set; }
        public int PesoBruto { get; set; }
    }
}
