using hangfire.api.Enums;

namespace hangfire.api.Models
{
    public class Agendamento
    {
        public Guid UId => Guid.NewGuid();

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public string? Body { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime DataInicio { get; set; }
        public TipoAgendamentoEnum TipoAgendamento { get; set; }
        public TipoVerboEnum TipoVerbo { get; set; }
        public bool Async { get; set; }
    }
}
