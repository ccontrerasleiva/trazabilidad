using System.ComponentModel;

namespace ViewModels.Enum
{
    public enum EstadoTren
    {
        [Description("Programado")]
        Programado,
        [Description("Confirmado")]
        Confirmado,
        [Description("Autorizado")]
        Autorizado,
        [Description("A Tiempo")]
        ATiempo,
        [Description("Incumpliendo")]
        Incumpliendo,
        [Description("Atrasado")]
        Atrasado,
        [Description("Finalizado")]
        Finalizado,
        [Description("Suprimido")]
        Suprimido


    }
}
