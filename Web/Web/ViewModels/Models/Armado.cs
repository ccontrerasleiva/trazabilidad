using System;
using System.Collections.Generic;
using ViewModels.Extensions;

namespace ViewModels.Models
{
    public class Armado : BaseModel
    {


        private string _stop_time;
        private string _stop_event;
        private string _start_time;
        private string _start_event;
        private string _condition;
        private string _locationId;
        private string _tag_count;
        private string _type;
        private string _objectId;
        private string _drivers;
        private string _status;
        private string _timestamp;
        private string _UUID;
        private bool _Procesado;
        private DateTime _Fecha;

        public string stop_time {get { return _stop_time; } set { _stop_time = value; }}
        public string stop_event { get { return _stop_event; } set { _stop_event = value; } }
        public string start_time { get { return _start_time; } set { _start_time = value; } }
        public string start_event { get { return _start_event; } set { _start_event = value; } }
        public string condition { get { return _condition; } set { _condition = value; } }
        public string locationId { get { return _locationId; } set { _locationId = value; } }
        public string tag_count { get { return _tag_count; } set { _tag_count = value; } }
        public string type { get { return _type; } set { _type = value; } }
        public string objectId { get { return _objectId; } set { _objectId = value; } }
        public string drivers { get { return _drivers; } set { _drivers = value; } }
        public string status { get { return _status; } set { _status = value; } }
        public string timestamp { get { return _timestamp; } set { _timestamp = value; } }
        public string UUID { get { return _UUID; } set { _UUID = value; } }
        public bool Procesado { get { return _Procesado; } set { _Procesado = value; } }
        public DateTime Fecha { get { return _Fecha; }set { _Fecha = value; } }

        public ICollection<MovArmado> ArmadoMovimiento { get; set; }








    }
}