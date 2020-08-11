using System.ComponentModel;

namespace ViewModels.Enum
{
    public enum TipoActividad
    {
        [Description("Servicio Ruta")]
        Servicio,
        [Description("Servicio Pasajero")]
        Pasajero,
        [Description("Servicio Patio")]
        Patio
    };
}
