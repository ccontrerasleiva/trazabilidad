using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TrazabilidadMovLocomotora : Extensions.BaseModel
    {
        private int _IdTrazabilidad;
        private int _IdLocomotora;
        
        public int IdTrazabilidad
        { get { return _IdTrazabilidad; } set { _IdTrazabilidad = value; } }

        public int IdLocomotora
        {
            get { return _IdLocomotora; }
            set { _IdLocomotora = value; }
        }


            public Trazabilidad Trazabilidad { get ;set;  }

        
        public Locomotora Locomotora { get ; set ; }

      
    }
}
