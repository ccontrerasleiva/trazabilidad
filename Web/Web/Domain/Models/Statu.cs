using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Statu : Extensions.BaseModel
    {


        private string _Descripcion;
        

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public ICollection<TrazabilidadMovCarro> TrazaMovCarro_Statu { get; set; }


    }
}