using System.ComponentModel;

namespace hangfire.api.Enums
{
    public enum TipoAgendamentoEnum
    {
        [Description("Único e Imediato")]
        UnicoImediato = 1,

        [Description("Único")]
        Unico = 2,

        [Description("Diário")]
        Diario = 3,

        [Description("Semanal")]
        Semanal = 4,

        [Description("Mensal")]
        Mensal = 5,

        [Description("Horário")]
        Horario = 6
    }
}
