using System.ComponentModel;

namespace ViewModels.Enum
{
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
}
