using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Models
{
    public class TrazabilidadMovLocomotora
    {
        private int _IdTrazabilidadMovLocomotora;
        private int _IdTrazabilidad;
        private int _IdLocomotora;


        [Key]
        public int IdTrazabilidadMovLocomotora { get { return _IdTrazabilidadMovLocomotora; } set { _IdTrazabilidadMovLocomotora = value; } }
        public int IdTrazabilidad { get { return _IdTrazabilidad; }set { _IdTrazabilidad= value; } }
        public int IdLocomotora { get { return _IdLocomotora; } set { _IdLocomotora = value; } }
        
        public Trazabilidad Trazabilidad { get; set; }
        public Locomotora Locomotora { get; set; }


    }
}
