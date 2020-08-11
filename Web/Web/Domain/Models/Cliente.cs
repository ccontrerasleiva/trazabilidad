
using System;
using System.Collections.Generic;


namespace Domain.Models
//namespace Testv3.Models
{

    public class Cliente : Extensions.BaseModel
    {


        private string _Nombre;
        private string _celular;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }

        public ICollection<Trazabilidad> TrazabilidadCliente { get; set; }


    }
}