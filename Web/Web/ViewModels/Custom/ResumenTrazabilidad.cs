using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Custom
{
    public class ResumenTrazabilidad
    {
        public string Ruta { get; set; }
        public string Cliente { get; set; }
        public string Celular_Cliente {get;set;}
        public string FechaRegistro { get; set; }
        public string FechaInicio { get; set; }
        public string FechaCierre{ get; set; }
        public string Rut_Conductor { get; set; }
        public string Conductor { get; set; }
        public string Celular_Conductor { get; set; }
        public string Observacion { get; set; }
        public string Locomotora { get; set; }
        public string Locomotora_Patente { get; set; }
        public string Carro { get; set; }
        public string Carro_Patente { get; set; }
        public string Contenedor { get; set; }
        public string Contenedor_Patente { get; set; }
        public string Statu { get; set; }
        public string Tag { get; set; }
        public string  CodigoSello { get; set; }
        public string PesoNeto { get; set; }
        public string PesoBruto { get; set; }
        public string PesoTara { get; set; }
        public string Sello { get; set; }
        public string ObjectId { get; set; }
        public string IdCV { get; set; }
        public string NumeroGuia { get; set; }
    }
}
