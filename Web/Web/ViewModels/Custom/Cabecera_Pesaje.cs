using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Custom
{
    public class Cabecera_Pesaje
    {
        public int IdTrazabilidad { get; set; }
        public string IdCV { get; set; }
        public string Locomotora_Patente { get; set; }
        public string FechaRegistro { get; set; }
        public string Locomotora { get; set; }
        public string Ruta { get; set; }
    public string NumeroGuia { get; set; }
    public int PesoNeto { get; set; }
        public int PesoBruto { get; set; }
        public int PesoTara { get; set; }

    }
}
