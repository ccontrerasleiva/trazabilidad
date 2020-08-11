using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//using System.ComponentModel.DataAnnotations;

//namespace Testv3.Models
namespace Domain.Models
{
    public class Carro : Extensions.BaseModel
    {


        private string _Descripcion;
        private int _Patente;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public int Patente
        {
            get { return _Patente; }
            set { _Patente = value; }
        }

        public ICollection<TrazabilidadMovCarro> TrazaMovCarro_Carro { get; set; }

    }
}