using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class MovArmado : Extensions.BaseModel
    {


        private int  _IdIGArmado;
        private string _last_read;
        private string _observationUUID;
        private string _locationId;
        private string _reads;
        private string _companyPrefix;
        private string _itemReference;
        private string _filterValue;
        private string _serialNumber;
        private string _first_read;
        private string _type;
        private string _objectId;
        private string _timestamp;
        private string _UUID;
        

        public int  IdIGArmado { get { return _IdIGArmado; } set { _IdIGArmado = value; }}
        public string last_read { get { return _last_read; } set { _last_read = value; } }
        public string observationUUID { get { return _observationUUID; } set { _observationUUID = value; } }
        public string locationId { get { return _locationId; } set { _locationId = value; } }
        public string reads { get { return _reads; } set { _reads = value; } }
        public string companyPrefix { get { return _companyPrefix; } set { _companyPrefix = value; } }
        public string itemReference { get { return _itemReference; } set { _itemReference = value; } }
        public string filterValue { get { return _filterValue; } set { _filterValue = value; } }
        public string serialNumber { get { return _serialNumber; } set { _serialNumber = value; } }
        public string first_read { get { return _first_read; } set { _first_read = value; } }
        public string type { get { return _type; } set { _type = value; } }
        public string objectId { get { return _objectId; } set { _objectId = value; } }
         public string timestamp { get { return _timestamp; } set { _timestamp = value; } }
        public string UUID { get { return _UUID; } set { _UUID = value; } }
        

        public Armado Armado { get; set; }








    }
}