using hangfire.api.Enums;
using hangfire.api.Models;

namespace hangfire.api.Services.Tarefas
{
    public class TarefaDiario : Tarefa
    {
        public override TipoAgendamentoEnum TipoAgendamento => TipoAgendamentoEnum.Diario;
        public TarefaDiario(IRestService restService) : base(restService){}
        public override Task Agendar(Agendamento agendamento)
        {
            var titulo = GetTitulo(agendamento);
            var dataAgendamento = agendamento.DataAgendamento;
            var cron = NovoCron.Criar(CronEnum.Diario, new Diario(dataAgendamento.Hour, dataAgendamento.Minute));
            agendamento.DataInicio = DateTime.Now;

            NovaAgendamento.Executar(() => _restService.Execute(titulo, agendamento), cron, agendamento.Id.ToString());

            return Task.CompletedTask;
        }
    }
}
