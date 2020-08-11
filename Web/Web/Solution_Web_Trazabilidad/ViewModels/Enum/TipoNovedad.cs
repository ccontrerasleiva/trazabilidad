using System.ComponentModel;

namespace ViewModels.Enum
{
    public enum TipoNovedad
    {
        [Description("Problema con la carga")]
        ProblemaConLaCarga,
        [Description("Accidente Personal")]
        AccidentePersonal,
        [Description("Accidente a Terceros")]
        AccidenteTerceros,
        [Description("Storage")]
        Storage,
        [Description("Carpas")]
        Carpas,
        [Description("Carros")]
        Carros,
        [Description("Vias y Comunicaciones")]
        ViasYComunicaciones,
        [Description("Ipa")]
        Ipa
    };
}
