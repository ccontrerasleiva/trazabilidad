
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
        private string _Sigla_Codelco;
        private decimal _Longitud;
        private decimal _Latitud;
        private DateTime _FechaHoraInicio;
        private DateTime _FechaHoraTermino;
        private string _Nombre;
        private string _Title;
        private int _Sentido;
        private string _Trocha;
        private int _Orden;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string Sigla_Codelco { get { return _Sigla_Codelco; } set { _Sigla_Codelco = value; } }

        public decimal Longitud { get { return _Longitud; } set { _Longitud = value; } }
        public decimal Latitud { get { return _Latitud; } set { _Latitud = value; } }

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

        public string Nombre { get { return _Nombre; }set { _Nombre = value; } }
        public string Title { get { return _Title; } set { _Title = value; } }
        public int Sentido { get { return _Sentido; } set { _Sentido = value; } }
        public string Trocha { get { return _Trocha; } set { _Trocha = value; } }

        public int Orden { get { return _Orden; } set { _Orden  = value; } }

        public ICollection<Trazabilidad> TrazabilidadRuta { get; set; }

        public ICollection<TrazaUbicacionContenedor> TrazaUbiRuta_Contenedor { get; set; }

        public ICollection<TrazaUbicacionCarro> TrazaUbiRuta_Carro { get; set; }

        public ICollection<TrazaUbicacionLocomotora> TrazaUbiRuta_Locomotora { get; set; }

    }
}
