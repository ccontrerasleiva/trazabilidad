using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Custom
{
    public class Cantidad_Activo
    {
        public string SiglaCodelco { get; set; }
        public string SiglaNombre { get; set; }
        public int Cantidad { get; set; }
        public int Subiendo { get; set; }
        public int Bajando { get; set; }
        public int Detenido { get; set; }
        public int Total { get; set; }
        public int Metrica { get; set; }
        public int Ancha { get; set; }
        public string Trocha { get; set; }


        //Estos son para los totales de los carros.
        public int Cantidad_Carro { get; set; }
        public int Subiendo_Carro { get; set; }
        public int Bajando_Carro {get;set;}
        public int Detenido_Carro { get; set; }
        public int Total_Carro { get; set; }
        public int Metrica_Carro { get; set; }
        public int Ancha_Carro { get; set; }

    }
}
