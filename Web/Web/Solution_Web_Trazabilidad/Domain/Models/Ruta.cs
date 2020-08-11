
using System;
using System.Collections.Generic;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//using System.ComponentModel.DataAnnotations;

namespace Domain.Models
//namespace Testv3.Models
{

    public class Ruta : Extensions.BaseModel
    {
        private string _Descripcion;
        private DateTime _FechaHoraInicio;
        private DateTime _FechaHoraTermino;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        
        public DateTime FechaHoraInicio
        {
            get { return _FechaHoraInicio; }
            set { _FechaHoraInicio= value; }
        }
        /* Id_Itinerario */

        
        public DateTime FechaHoraTermino
        {
            get { return _FechaHoraTermino; }
            set { _FechaHoraTermino = value; }
        }

        public ICollection<Trazabilidad> TrazabilidadRuta { get; set; }
    }
}
