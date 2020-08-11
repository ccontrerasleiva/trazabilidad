
using System;
using System.Collections.Generic;

namespace ViewModels.Models
{
    public class TrazaUbicacionLocomotora : BaseModel
    {


        private int _IdTrazabilidadMovLocomotora;
        private int _IdLocomotora;
        private int _IdRuta;
        private int _PesoNeto;

        public int IdLocomotora { get { return _IdLocomotora; } set { _IdLocomotora= value; } }
        public int IdRuta { get { return _IdRuta; } set { _IdRuta = value; } }
        public int PesoNeto { get { return _PesoNeto; } set { _PesoNeto = value; } }
        public int IdTrazabilidadMovCarro { get { return _IdTrazabilidadMovLocomotora; } set { _IdTrazabilidadMovLocomotora = value; } }

        private Locomotora _DescripcionLocomotora;
        public Locomotora DescripcionLocomotora { get { return _DescripcionLocomotora; } set { _DescripcionLocomotora = value; } }

        private Ruta _DescripcionRuta;
        public Ruta DescripcionRuta { get { return _DescripcionRuta; } set { _DescripcionRuta = value; } }

    }
}