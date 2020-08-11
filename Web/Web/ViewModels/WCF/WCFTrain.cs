namespace ViewModels.WCF
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public class WCFTrain : WCFBaseModel
    {
        public string Code { get; set; }

        #region Collections

        public ICollection<WCFTrainRoute> Routes { get; set; }
        //public ICollection<FreightCar> Cars { get; set; }
        //public ICollection<Locomotive> Locomotives { get; set; }
        //public ICollection<GPSLog> GPSLogs { get; set; }

        #endregion Collections
    }
}