using System;
using System.Collections.Generic;

//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//using System.ComponentModel.DataAnnotations;

//namespace Testv3.Models
namespace Domain.Models
{
    public class Contenedor : Extensions.BaseModel
    {


        private string _Descripcion;
        private int _PesoTara;
        private int _Patente;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public int PesoTara
        {
            get { return _PesoTara; }
            set { _PesoTara = value; }
        }

        public int Patente
        {
            get { return _Patente; }
            set { _Patente = value; }
        }

        public ICollection<TrazabilidadMovCarro> TrazaMovCarro_Contenedor { get; set; }

    }
}