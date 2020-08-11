using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Custom
{
    public class HistoricoPatente
    {
        public int Id { get; set; }
        public  string FechaLectura { get; set; }
        public string Ubicacion { get; set; }
        public string UUID { get; set; }
        public string Patente { get; set; }
    }
}
