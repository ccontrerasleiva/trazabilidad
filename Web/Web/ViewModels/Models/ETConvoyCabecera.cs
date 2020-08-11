using System;
using System.Collections.Generic;

namespace ViewModels.Models
{
    public class ETConvoyCabecera : BaseModel
    {
        private int _CnvBseCod;
        private int _CnvBasCod;
        private string _CnvId;
        private string _CnvObs;
        private int _CnvCicPesCod;
        private int _CnvChoid;
        private string _CnvChoDid;
        private string _IdCV;


        public int CnvBseCod { get { return _CnvBseCod; } set { _CnvBseCod = value; } }
        public int CnvBasCod { get { return _CnvBasCod; } set { _CnvBasCod = value; } }
        public string CnvId { get { return _CnvId; } set { _CnvId = value; } }
        public string CnvObs { get { return _CnvObs; } set { _CnvObs = value; } }
        public int CnvCicPesCod { get { return _CnvCicPesCod; } set { _CnvCicPesCod = value; } }
        public int CnvChoid { get { return _CnvChoid; } set { _CnvChoid = value; } }
        public string CnvChoDid { get { return _CnvChoDid; } set { _CnvChoDid = value; } }
        public string IdCV { get { return _IdCV; } set { _IdCV = value; } }

        public ICollection<PesoConvoy> ETConvoyCabecera_Peso { get; set; }
    }
}