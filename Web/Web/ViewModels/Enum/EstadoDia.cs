using System.ComponentModel;

namespace ViewModels.Enum
{
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
