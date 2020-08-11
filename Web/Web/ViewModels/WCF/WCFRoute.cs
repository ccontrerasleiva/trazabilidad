using System;
using System.Collections.Generic;

namespace ViewModels.WCF
{
    public class WCFRoute : WCFBaseModel
    {
        /// <summary>
        /// Orden del itinerario dentro de la ruta.
        /// </summary>
        public int Order { get; set; }

        ///// <summary>
        ///// Itinerario al que pertenece esta <see cref="Route"/>
        ///// </summary>
        //public Schedule Schedule { get; set; }
        /// <summary>
        /// Estación de Destino
        /// </summary>
        public WCFEstacion Destination { get; set; }

        /// <summary>
        /// Estación de Origen
        /// </summary>
        public WCFEstacion Origin { get; set; }

        /// <summary>
        /// Hora de salida desde <see cref="Origin"/>
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// Hora de llegada a <see cref="Destination"/>
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// Tiempo programado para la detención de la locomotora.
        /// </summary>
        public TimeSpan StoppedTime { get; set; }

        /// <summary>
        /// Distancia entre <see cref="Origin"/> - <see cref="Destination"/>
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Notas adicionales de la ruta.
        /// </summary>
        public string Notes { get; set; }

        #region Collections

        /// <summary>
        /// Novedades del itinerario.
        /// </summary>
        //public ICollection<News> News { get; set; }
        public ICollection<WCFTrainRoute> Trains { get; set; }

        #endregion Collections

        //#region FK
        //public int ScheduleId { get; set; }
        //public int OriginId { get; set; }
        //public int DestinationId { get; set; }
        //#endregion
    }
}