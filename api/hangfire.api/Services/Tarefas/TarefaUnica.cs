using hangfire.api.Enums;
using hangfire.api.Models;

namespace hangfire.api.Services.Tarefas
{
    public class TarefaUnica : Tarefa
    {
        public override TipoAgendamentoEnum TipoAgendamento => TipoAgendamentoEnum.Unico;
        public TarefaUnica(IRestService restService) : base(restService){}
        public override Task Agendar(Agendamento agendamento)
        {
            var titulo = GetTitulo(agendamento);
            var dataAgendamento = agendamento.DataAgendamento;
            var minutes = (dataAgendamento - DateTime.Now).TotalMinutes;
            var dateTimeOffset = DateTimeOffset.Now.AddMinutes(minutes);

            agendamento.DataInicio = DateTime.Now;

            NovaTarefaUnica.Executar(() => _restService.Execute(titulo, agendamento), dateTimeOffset);

            return Task.CompletedTask;
        }
    }
}
