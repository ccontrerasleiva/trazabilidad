namespace ViewModels.WCF
{
    using System;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public class WCFBaseModel
    {
        [DataMember]
        /// <summary>
        /// Identificador de la Entidad
        /// </summary>
        public int Id { get; set; }

        [DataMember]
        /// <summary>
        /// Fecha de creación del Elemento en BD.
        /// </summary>
        public DateTime Created { get; set; }

        [DataMember]
        /// <summary>
        /// Fecha de la última actualización del elemento.
        /// </summary>
        public DateTime Updated { get; set; }
    }
}