namespace ViewModels.WCF
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public class WCFTrainRoute : WCFBaseModel
    {
        [DataMember]
        /// <summary>
        /// Indica si el Tren está dentro de la ruta.
        /// </summary>
        public bool InRoute { get; set; }

        [DataMember]
        /// <summary>
        /// Fecha de salida del tren para la ruta
        /// </summary>
        public DateTime DepartureDate { get; set; }

        [DataMember]
        /// <summary>
        /// Fecha de llegada del tren desde origen y destino
        /// </summary>
        public DateTime ArrivalDate { get; set; }

        [DataMember]
        /// <summary>
        /// Tiempo de viaje registrado para el tren entre <see cref="Route.Origin"/> y <see cref="Route.Destination"/>
        /// </summary>
        public TimeSpan TravelTime { get; set; }

        [DataMember]
        /// <summary>
        /// Tiempo en el que el tren estuvo detenido
        /// </summary>
        public TimeSpan StoppedTime { get; set; }

        [DataMember]
        /// <summary>
        /// Distancia Recorrida
        /// </summary>
        public double Distance { get; set; }

        [DataMember]
        public WCFTrain Train { get; set; }

        [DataMember]
        public WCFRoute Route { get; set; }

        #region Collections

        public ICollection<WCFTrainCrewman> Crew { get; set; }

        #endregion Collections
    }
}