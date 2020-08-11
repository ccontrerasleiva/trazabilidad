using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Trazabilidad.Helpers
{
    public class Enumerador
    {
        public enum RolTripulante
        {
            [Description("Maquinista Principal")]
            Maquinista,
            [Description("Jefe de Tren")]
            JefeDeTren,
            [Description("Maquinista Práctica")]
            MaquinistaPractica,
            [Description("Ayudante")]
            Ayudante,
        };

        public enum TipoTren
        {
            [Description("Normal")]
            Normal,
            [Description("Spot")]
            Spot,
            [Description("Especial")]
            Especial
        };

        public enum EstadoTren
        {
            [Description("Programado")]
            Programado,
            [Description("Autorizado")]
            Autorizado,
            [Description("A Tiempo")]
            ATiempo,
            [Description("Atrasado")]
            Atrasado,
            [Description("Incumpliendo")]
            Incumpliendo
        };
        public enum Incumplimiento
        {
            [Description("Cumple")]
            Cumple,
            [Description("No Cumple")]
            NoCumple
        };
        public enum EstadoJornada
        {
            [Description("Aprobada")]
            Aprobada,
            [Description("Rechazada")]
            Rechazada,
            [Description("Aprobada con Observaciones")]
            AprobadaConObs
        };

        public enum TipoActividad
        {
            [Description("Servicio")]
            Servicio,
            [Description("Pasajero")]
            Pasajero,
            [Description("Patio")]
            Patio
        };

        public enum EstadoActividad
        {
            [Description("Programado")]
            Programado,
            [Description("Iniciado")]
            Iniciado,
            [Description("Finalizado")]
            Finalizado,
            [Description("Ausente")]
            Ausente
        };

        public enum Locomotora
        {
            [Description("Principal")]
            Principal,
            [Description("Secundario")]
            Secundario
        };

        public enum EstadoTracion
        {
            [Description("Principal")]
            Principal,
            [Description("Secundario")]
            Secundario
        };

        public enum Viatico
        {
            [Description("Colación")]
            Colacion,
            [Description("Alojamiento")]
            Alojamiento
        };

        public enum Cargo
        {
            [Description("Tripulante de Patio")]
            TripulantePatio,
            [Description("Tripulante de Ruta")]
            TripulanteRuta
        };

        public enum Disponibilidad
        {
            [Description("Disponible")]
            Disponible,
            [Description("Libre")]
            Libre,
            [Description("Reposo")]
            Reposo,
            [Description("Servicio")]
            Servicio,
            [Description("Ausencia")]
            Ausencia
        };

        public enum TipoNovedad
        {
            [Description("Problema con la carga")]
            ProblemaConLaCarga,
            [Description("Accidente Personal")]
            AccidentePersonal,
            [Description("Accidente a Terceros")]
            AccidenteTerceros,
            [Description("Storage")]
            Storage,
            [Description("Carpas")]
            Carpas,
            [Description("Carros")]
            Carros,
            [Description("Vias y Comunicaciones")]
            ViasYComunicaciones,
            [Description("Ipa")]
            Ipa
        };

        public enum MotivoAusencia
        {
            [Description("Sin Justificar")]
            SinJustificar,
            [Description("Vacaciones")]
            Vacaciones,
            [Description("Licencia Médica")]
            LicenciaMedica,
            [Description("Permiso Sindical")]
            PermisoSindical,
            [Description("Mutual")]
            Mutual,
            [Description("Devolución Festival")]
            DevolucionFestival
        };

        public enum TipoPatio
        {
            [Description("Sin Justificar")]
            SinJustificar,
            [Description("Vacaciones")]
            Vacaciones,
            [Description("Licencia Médica")]
            LicenciaMedica
        };

        public enum EstadoDia
        {
            [Description("Sin Asignar")]
            SinAsignar,
            [Description("Libre")]
            Libre,
            [Description("Disponible")]
            Disponible,
            [Description("Servicio")]
            Servicio
        };


    }
}