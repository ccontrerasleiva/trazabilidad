
using System.ComponentModel;

namespace Domain
{
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
}
