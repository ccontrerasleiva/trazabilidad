using System.ComponentModel;

namespace ViewModels.Enum
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
}
