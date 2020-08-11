using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Paso : Extensions.BaseModel
    {

        private string _Descripcion;

        public string Descripcion { get { return _Descripcion; } set { _Descripcion = value; }}


    }
}