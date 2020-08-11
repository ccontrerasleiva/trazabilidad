using System;
using System.Collections.Generic;


namespace Domain.Models
{

    public class Tripulante_old : Extensions.BaseModel
    {


        /* Id_Tren_Locomotora */


        private Tren_Locomotora _Tren_Locomotora;

        public Tren_Locomotora Tren_Locomotora
        {
            get { return _Tren_Locomotora; }
            set { _Tren_Locomotora = value; }
        }

        /* Id_Tripulante_Persona */
        private Tripulante_Persona _Tripulante_Persona;
        public Tripulante_Persona Tripulante_Persona
        {
            get { return _Tripulante_Persona; }
            set { _Tripulante_Persona = value; }
        }

        /* Id_Origen */

        private Estacion _Origen;

        public Estacion Origen
        {
            get { return _Origen; }
            set { _Origen = value; }
        }

        /* Id_Destino */

        private Estacion _Destino;

        public Estacion Destino
        {
            get { return _Destino; }
            set { _Destino = value; }
        }



        /* Rol */

        private int _Rol;

        public int Rol
        {
            get { return _Rol; }
            set { _Rol = value; }
        }

        /* Ausente */

        private bool? _Ausente;

        public bool? Ausente
        {
            get { return _Ausente; }
            set { _Ausente = value; }
        }

        ///* Ausente */

        //private bool? _Deshabilitado;

        //public bool? Deshabilitado
        //{
        //    get { return _Deshabilitado; }
        //    set { _Deshabilitado = value; }
        //}



        #region Collections

        public ICollection<Actividad> Actividades { get; set; }
        //public ICollection<HapaTripulante> HapaTripulantes { get; set; }


        #endregion Collections

        #region FK

        public int Id_Origen { get; set; }
        public int Id_Destino { get; set; }
        public int Id_Tripulante_Persona { get; set; }
        public int Id_Tren_Locomotora { get; set; }

        #endregion FK
    }
}