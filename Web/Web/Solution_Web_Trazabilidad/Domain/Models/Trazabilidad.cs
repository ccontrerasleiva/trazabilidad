using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Trazabilidad : Extensions.BaseModel
    {
        private int _IdRuta;
        private int _IdCliente;
        private DateTime _FechaRegistro;
        private DateTime _FechaInicio;
        private DateTime _FechaCierre;
        private int _IdConductor;
        private string _Observacion;
        private int _IdBase;
        private int _IdBascula;
        private string _IdCV;
        private int  _IdEtruck;


        public int IdRuta
        { get { return _IdRuta; } set { _IdRuta = value; } }

        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }
        public DateTime FechaRegistro
        {
            get { return _FechaRegistro; }
            set { _FechaRegistro = value; }
        }
        public DateTime FechaInicio
        { get { return _FechaInicio; } set { _FechaInicio = value; } }
        public DateTime FechaCierre
        { get { return _FechaCierre; } set { _FechaCierre = value; } }
        public int IdConductor
        { get { return _IdConductor; } set { _IdConductor = value; } }
        public string Observacion
        { get { return _Observacion; } set { _Observacion = value; } }

        public int IdBase { get { return _IdBase; } set { _IdBase = value; } }
        public int IdBascula { get { return _IdBascula; } set { _IdBascula = value; } }
        public string IdCV { get { return _IdCV;} set { _IdCV = value; } }
        public int IdEtruck { get { return _IdEtruck; } set { _IdEtruck = value; } }


        /*  IdRuta */
        private Ruta _DescripcionRuta;  
        public Ruta DescripcionRuta
        { get { return _DescripcionRuta; } set { _DescripcionRuta = value; } }

        /* IdCliente */
        private Cliente _DescripconCliente;
        public Cliente DescripcionCliente
        { get { return _DescripconCliente; } set { _DescripconCliente = value; } }

        /* IdConductor */
        private Conductor _DescripcionConductor;
        public Conductor DescripcionConductor
        { get { return _DescripcionConductor; } set { _DescripcionConductor = value; } }


        public ICollection<TrazabilidadMovLocomotora> TrazaMoviLoco_Traza { get; set; }
        public ICollection<TrazabilidadMovCarro> TrazaMoviLoco_Carro { get; set; }

    }
}
