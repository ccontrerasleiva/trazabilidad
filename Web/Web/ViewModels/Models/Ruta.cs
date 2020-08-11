
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Models
{
    public class Ruta : BaseModel
    {

        //PROPIEDADES PARA EL MODELO

            [Key]
            public int IdRuta { get; set; }

        public string Descripcion { get; set; }

        public string Sigla_Codelco { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public DateTime FechaHoraInicio{ get; set; }

        public DateTime FechaHoraTermino{ get; set; }

        public string Nombre { get; set; }
        public string Title { get; set; }
        public int Sentido { get; set; }

        public string Trocha { get; set; }

        public int orden { get; set; }


    }
}
