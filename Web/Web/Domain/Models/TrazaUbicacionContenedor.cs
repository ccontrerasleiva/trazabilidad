using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TrazaUbicacionContenedor : Extensions.BaseModel
    {
        private int _IdTrazabilidadMovCarro;
        private int _IdContenedor;
        private int _IdRuta;
        private int _PesoNeto;

        
        public int IdContenedor { get { return _IdContenedor; } set { _IdContenedor = value; } }
        public int IdRuta { get { return _IdRuta; } set { _IdRuta = value; } }
        public int PesoNeto { get { return _PesoNeto; } set { _PesoNeto = value; } }
        public int IdTrazabilidadMovCarro { get { return _IdTrazabilidadMovCarro; } set { _IdTrazabilidadMovCarro = value; } }


        private Contenedor _DescripcionContenedor;
        public Contenedor DescripcionUbiContenedor { get { return _DescripcionContenedor; } set { _DescripcionContenedor = value; } }

        private Ruta _DescripcionRuta;
        public Ruta DescripcionUbiRuta { get { return _DescripcionRuta; } set { _DescripcionRuta = value; } }


    }
}
