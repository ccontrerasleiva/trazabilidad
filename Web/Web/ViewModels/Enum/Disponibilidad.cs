using System.ComponentModel;

namespace ViewModels.Enum
{
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
}
