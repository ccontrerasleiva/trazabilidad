using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TrazaUbicacionCarro : Extensions.BaseModel
    {
        private int _IdTrazabilidadMovCarro;
        private int _IdCarro;
        private int _IdRuta;
        private int _PesoNeto;

        
        public int IdCarro { get { return _IdCarro; } set { _IdCarro= value; } }
        public int IdRuta { get { return _IdRuta; } set { _IdRuta = value; } }
        public int PesoNeto { get { return _PesoNeto; } set { _PesoNeto = value; } }
        public int IdTrazabilidadMovCarro { get { return _IdTrazabilidadMovCarro; } set { _IdTrazabilidadMovCarro = value; } }


        private Carro _DescripcionCarro;
        public Carro DescripcionUbiCarro { get { return _DescripcionCarro; } set { _DescripcionCarro = value; } }

        private Ruta _DescripcionRuta;
        public Ruta DescripcionUbiRuta { get { return _DescripcionRuta; } set { _DescripcionRuta = value; } }


    }
}
