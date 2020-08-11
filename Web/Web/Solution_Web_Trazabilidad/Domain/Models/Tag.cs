using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Tag : Extensions.BaseModel
    {


        private string _Descripcion;
        

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }


        public ICollection<TrazabilidadMovCarro> TrazaMovCarro_Tag { get; set; }

    }
}