using System;

namespace ViewModels.Models
{
    public class BaseModel
    {
        /// <summary>
        /// Identificador de la Entidad
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Fecha de creación del Elemento en BD.
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Fecha de la última actualización del elemento.
        /// </summary>
        public DateTime Updated { get; set; }
        /// <summary>
        /// Habilitado o no.
        /// </summary>
        public bool Deshabilitado { get; set; }
    }
}
