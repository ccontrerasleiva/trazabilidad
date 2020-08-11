
namespace ViewModels.Enum
{
    using System.ComponentModel;
    public enum EstadoJornada
    {
        [Description("No Iniciada")]
        NoIniciada,
        [Description("Iniciado")]
        Iniciado,
        [Description("Finalizado")]
        Finalizado,
        [Description("Ausente")]
        Ausente
    };
}
