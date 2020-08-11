using System.ComponentModel;

namespace ViewModels.Enum
{
    public enum Cargo
    {
        [Description("Tripulante de Patio")]
        TripulantePatio = 1,
        [Description("Tripulante de Linea")]
        TripulanteRuta = 2,
        [Description("Jefe de Tren")]
        JefedeTren = 3,
        [Description("Ayudante de Maquinista")]
        AyudantedeMaquinista = 4
    };
};

