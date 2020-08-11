using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Conductor : Extensions.BaseModel
    {


        private string _Rut;
        private string _Nombres;
        private string _Apellidos;
        private string _Celular;

        public string Rut
        {
            get { return _Rut; }
            set { _Rut = value; }
        }

        public string Nombres
        {
            get { return _Nombres; }
            set { _Nombres = value; }
        }

        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }
        public string Celular
        {
            get { return _Celular; }
            set { _Celular = value; }
        }

        public ICollection<Trazabilidad> TrazabilidadConductor { get; set; }

    }
}