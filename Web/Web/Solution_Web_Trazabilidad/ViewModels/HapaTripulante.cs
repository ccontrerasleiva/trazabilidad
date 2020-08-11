
using System;
namespace ViewModels.Models
{
    public class HapaTripulante : BaseModel
    {



        public Tripulante Tripulante { get; set; }

        public Tiempo_Hapa Hapa { get; set; }

        //public DateTime Fecha_Creacion { get; set; }

        //public DateTime Fecha_Modificacion { get; set; }
        #region FK
        public int Hapas { get; set; }
        public int Tripulantes { get; set; }
        #endregion

    }
}
