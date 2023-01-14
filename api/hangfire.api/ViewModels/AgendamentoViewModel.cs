using hangfire.api.Enums;

namespace hangfire.api.ViewModels
{
    public class AgendamentoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomeCompleto { get; set; }
        public string Url { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime DataInicio { get; set; }
        public TipoAgendamentoEnum TipoAgendamento { get; set; }
        public string Agendamento { get; set; }
        public TipoVerboEnum TipoVerbo { get; set; }
        public string Verbo { get; set; }
        public TipoServiceEnum TipoService { get; set; }
        public string Service { get; set; }
        public object Body { get; set; }

        public string JobId { get; set; }
        public bool Async { get; set; }
    }
}
