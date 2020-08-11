using System.ComponentModel;

namespace ViewModels.Enum
{
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
}
