using System;
using System.Collections.Generic;

namespace ViewModels.Models
{
    public class TrazaUbicacionContenedor : BaseModel
    {


        private int _IdTrazabilidadMovContenedor;
        private int _IdContenedor;
        private int _IdRuta;
        private int _PesoNeto;

        public int IdContenedor { get { return _IdContenedor; } set { _IdContenedor = value; } }
        public int IdRuta { get { return _IdRuta; } set { _IdRuta = value; } }
        public int PesoNeto { get { return _PesoNeto; } set { _PesoNeto = value; } }
        public int IdTrazabilidadMovContenedor { get { return _IdTrazabilidadMovContenedor; } set { _IdTrazabilidadMovContenedor = value; } }

        private Contenedor _DescripcionContenedor;
        public Contenedor DescripcionContenedor { get { return _DescripcionContenedor; } set { _DescripcionContenedor = value; } }

        private Ruta _DescripcionRuta;
        public Ruta DescripcionRuta { get { return _DescripcionRuta; } set { _DescripcionRuta = value; } }

    }
}