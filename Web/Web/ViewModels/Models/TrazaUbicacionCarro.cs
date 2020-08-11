using System;
using System.Collections.Generic;

namespace ViewModels.Models
{
    public class TrazaUbicacionCarro : BaseModel
    {


        private int _IdTrazabilidadMovCarro;
        private int _IdCarro;
        private int _IdRuta;
        private int _PesoNeto;

        public int IdCarro { get { return _IdCarro; } set { _IdCarro= value; } }
        public int IdRuta { get { return _IdRuta; } set { _IdRuta = value; } }
        public int PesoNeto { get { return _PesoNeto; } set { _PesoNeto = value; } }
        public int IdTrazabilidadMovCarro { get { return _IdTrazabilidadMovCarro; } set { _IdTrazabilidadMovCarro = value; } }

        private Contenedor _DescripcionCarro;
        public Contenedor DescripcionCarro { get { return _DescripcionCarro; } set { _DescripcionCarro = value; } }

        private Ruta _DescripcionRuta;
        public Ruta DescripcionRuta { get { return _DescripcionRuta; } set { _DescripcionRuta = value; } }

    }
}