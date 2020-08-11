namespace ViewModels.WCF
{
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public class WCFTrainCrewman : WCFBaseModel
    {
        [DataMember]
        /// <summary>
        /// ID del Usuario en el Active Directory de FEPASA.
        /// </summary>
        public string AzureID { get; set; }

        /// <summary>
        /// Rol del Tripulante.
        /// <list type="bulet">
        ///     <item>
        ///         <description>0 - Pasajero</description>
        ///     </item>
        ///     <item>
        ///         <description>1 - Maquinista</description>
        ///     </item>
        ///     <item>
        ///         <description>2- Jefe de Tren</description>
        ///     </item>
        /// </list>
        /// </summary>
        [DataMember]
        public int Role { get; set; }

        [DataMember]
        public WCFTrainRoute TrainRoute { get; set; }
    }
}