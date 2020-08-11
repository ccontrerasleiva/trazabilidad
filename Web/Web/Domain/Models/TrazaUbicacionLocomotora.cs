using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TrazaUbicacionLocomotora : Extensions.BaseModel
    {
        private int _IdTrazabilidadMovLocomotora;
        private int _IdLocomotora;
        private int _IdRuta;
        private int _PesoNeto;

        
        public int IdLocomotora { get { return _IdLocomotora; } set { _IdLocomotora= value; } }
        public int IdRuta { get { return _IdRuta; } set { _IdRuta = value; } }
        public int PesoNeto { get { return _PesoNeto; } set { _PesoNeto = value; } }
        public int IdTrazabilidadMovLocomotora { get { return _IdTrazabilidadMovLocomotora; } set { _IdTrazabilidadMovLocomotora = value; } }


        private Locomotora _DescripcionLocomotora;
        public Locomotora DescripcionUbiLocomotora { get { return _DescripcionLocomotora; } set { _DescripcionLocomotora = value; } }

        private Ruta _DescripcionRuta;
        public Ruta DescripcionUbiRuta { get { return _DescripcionRuta; } set { _DescripcionRuta = value; } }


    }
}
