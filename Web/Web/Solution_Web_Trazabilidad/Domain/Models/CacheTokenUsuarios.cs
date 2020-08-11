
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Domain.Models
{

    public class CacheTokenUsuarios : Extensions.BaseModel
    {



        /* id_usuario_web */

        private Int32 _id_usuario_web;
        public Int32 id_usuario_web
        {
            get { return _id_usuario_web; }
            set { _id_usuario_web = value; }
        }

        /* bits_cache */

        private Int32 _bits_cache;
        public Int32 bits_cache
        {
            get { return _bits_cache; }
            set { _bits_cache = value; }
        }

        /* ultima_escritura */

        private DateTime _ultima_escritura;
        public DateTime ultima_escritura
        {
            get { return _ultima_escritura; }
            set { _ultima_escritura = value; }
        }

    }
}
