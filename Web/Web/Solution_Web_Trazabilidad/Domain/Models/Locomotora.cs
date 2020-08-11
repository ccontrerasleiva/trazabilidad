using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Locomotora : Extensions.BaseModel
    {

        private string _Descripcion;
        private string _Patente;
        private int _PesoTara;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        

        public string Patente
        {
            get { return _Patente; }
            set { _Patente = value; }
        }
              

        public int PesoTara
        {
            get { return _PesoTara; }
            set { _PesoTara = value; }
        }


        //public ICollection<TrazabilidadMovLocomotora> Trazabilidad_LocomotoraMov { get; set; }
        public ICollection<TrazabilidadMovLocomotora> TrazaMoviLoco_Loco{ get; set; }

    }
}