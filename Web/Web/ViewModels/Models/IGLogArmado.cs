using System;
using System.Collections.Generic;
using ViewModels.Extensions;

namespace ViewModels.Models
{
    public class IGLogArmado : BaseModel2
    {


        private string _Texto;
        private string _Estado;
        private string _Descripcion_Estado;
        private DateTime _Fecha;

        public string Texto {get { return _Texto; } set { _Texto = value; }}
        public string Estado { get { return _Estado; } set { _Estado = value; } }
        public string Descripcion_Estado { get { return _Descripcion_Estado; } set { _Descripcion_Estado = value; } }

        public DateTime Fecha { get { return _Fecha; } set { _Fecha = value; } }

        //public ICollection<IGMovArmado2> ArmadoMovimiento { get; set; }








    }
}