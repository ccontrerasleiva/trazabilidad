using System;
using System.Collections.Generic;

namespace ViewModels.Models
{
    public class Locomotora : BaseModel
    {

        private string _Descripcion { get; set; }
        private string _Patente { get; set; }
        private int _PesoTara { get; set; }

        public string Descripcion { get { return _Descripcion; } set { _Descripcion = value; } }
        public string Patente { get { return _Patente; } set { _Patente = value; } }
        public int PesoTara { get { return _PesoTara; }set { _PesoTara = value; } }

        public ICollection<TrazabilidadMovLocomotora> TrazaMoviLoco_Loco { get; set; }
    }
}