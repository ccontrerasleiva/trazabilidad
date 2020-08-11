namespace Domain.Extensions
{
    using System;

    /// <summary>
    /// Entidad base, heredada por las que componen el modelo.
    /// </summary>
    public abstract class BaseModel
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
        public bool Deshabilitado { get; set; }
    }
}