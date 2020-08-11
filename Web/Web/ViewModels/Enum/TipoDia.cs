using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Enum
{
    public enum TipoDia
    {
        [Description("Normal")]
        Normal,
        [Description("Domingo")]
        Domingo,
        [Description("Feriado")]
        Feriado,
        [Description("Domingo Feriado")]
        DomingoFeriado
    };
}
