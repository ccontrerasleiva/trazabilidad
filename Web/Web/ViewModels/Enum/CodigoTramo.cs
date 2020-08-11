using System.ComponentModel;

namespace ViewModels.Enum
{
    public enum CodigoTramo
    {

        [Description("Ramal Ventana - Aconcagua")]
        VE_AC,
        [Description("Ramal Chagres - Saladillo")]
        CG_SD,
        [Description("Ramal Maipu - San Antonio")]
        MU_SA,
        [Description("Ramal Barón - Puerto Montt")]
        BR_PM,
        [Description("Ramal Andalien - Lirquén")]
        LQ_AD,
        [Description("Ramal Buenuraqui - Horcones")]
        BU_HO,
        [Description("Ramal Colliguay - Nueva Aldea")]
        CV_NA,
        [Description("Ramal Arenal - Talcahuano")]
        AR_TH,
        [Description("Ramal Puerto")]
        PT,
        [Description("Ramal Paloma")]
        XP,
    }
}



//llenarEstacionesPrincipal();
//llenarSubrecorridoMU_SA();
//llenarSubrecorridoLL_SD();
//llenarSubrecorridoVE_AC();