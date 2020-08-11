using System.ComponentModel;

namespace ViewModels.Enum
{
    public enum TipoTren
    {
        [Description("Normal")]
        Normal,
        [Description("Spot")]
        Spot,
        [Description("Especial")]
        Especial
    };
}
