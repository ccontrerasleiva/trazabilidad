using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class PesoConvoy : Extensions.BaseModel
    {


        private int _IdETConvoyCabecera;
        private string _Descripcion;
        private DateTime _Fecha;
        

        public int IdETConvoyCabecera { get { return _IdETConvoyCabecera; }set { _IdETConvoyCabecera = value; } }
        public string Descripcion {get { return _Descripcion; }set { _Descripcion = value; }}
        public DateTime Fecha { get { return _Fecha; } set { _Fecha = value; } }

    }
}