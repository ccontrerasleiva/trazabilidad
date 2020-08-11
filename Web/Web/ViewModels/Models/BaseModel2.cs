﻿using System;

namespace ViewModels.Extensions
{
    using System;

    /// <summary>
    /// Entidad base, heredada por las que componen el modelo.
    /// </summary>
    public class BaseModel2
    {
        /// <summary>
        /// Identificador de la Entidad
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fecha de creación del Elemento en BD.
        /// </summary>
        //public DateTime Created { get; set; }
        //public DateTime Updated { get; set; }
        //public bool Deshabilitado { get; set; }
    }
}