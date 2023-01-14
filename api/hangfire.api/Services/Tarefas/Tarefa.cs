using hangfire.api.Enums;
using hangfire.api.Extensions;
using hangfire.api.Models;
using Hangfire;
using System.Linq.Expressions;

namespace hangfire.api.Services.Tarefas
{
    public abstract class Tarefa 
    {
        protected readonly IRestService _restService;
        public abstract TipoAgendamentoEnum TipoAgendamento { get; }
        public abstract Task Agendar(Agendamento agendamento);
        public Tarefa(IRestService restService)
        {
            _restService = restService;
        }
        protected string GetTitulo(Agendamento command)
        {
            var tiposAgendamentos = typeof(TipoAgendamentoEnum).ToEnumList();
            var tipoAgendamento = tiposAgendamentos[(int)command.TipoAgendamento];

            var nomeTarefa = command.Nome;
            var tipoService = Enum.GetName(command.TipoService.GetType(), (int)command.TipoService);
            var verbo = Enum.GetName(command.TipoVerbo.GetType(), (int)command.TipoVerbo);
            var url = command.Url;
            var process = command.Async ? "ASYNC" : "sync";

            return $"{nomeTarefa}: {tipoAgendamento} - {tipoService} - {verbo} - {process} - {url}";
        }
    }
}
