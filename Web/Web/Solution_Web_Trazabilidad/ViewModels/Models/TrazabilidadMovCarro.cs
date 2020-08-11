using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Models
{
    public class TrazabilidadMovCarro
    {
        private int _IdTrazabilidad;
        private int _IdCarro;
        private int _IdContenedor;
        private int _IdStatusContenedor;
        private int _IdTag;
        private string _CodigoSello;
        private int _PesoNeto;
        private int _PesoBruto;
        private int _PesoTara;
        private int _Sello;

        public int IdTrazabilidad { get { return _IdTrazabilidad; } set { _IdTrazabilidad = value; } }
        public int IdCarro { get { return _IdCarro; } set { _IdCarro = value; } }
        public int IdContenedor { get { return _IdContenedor; } set { _IdContenedor = value; } }
        public int IdStatusContenedor { get { return _IdStatusContenedor; } set { _IdStatusContenedor = value; } }
        public int IdTag { get { return _IdTag; } set { _IdTag = value; } }
        public string CodigoSello { get { return _CodigoSello; } set { _CodigoSello = value; } }
        public int PesoNeto { get { return _PesoNeto; } set { _PesoNeto = value; } }
        public int PesoBruto { get { return _PesoBruto; } set { _PesoBruto = value; } }
        public int PesoTara { get { return _PesoTara; } set { _PesoTara = value; } }
        public int Sello { get { return _Sello; } set { _Sello = value; } }

        public Trazabilidad Trazabilidad { get; set; }
        public Carro Carro { get; set; }
        public Contenedor Contenedor { get; set; }
        public Statu Statu { get; set; }
        public Tag Tag { get; set; }


    }
}
