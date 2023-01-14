using hangfire.api.Enums;
using hangfire.api.Models;

namespace hangfire.api.Services.Tarefas
{
    public class TarefaUnicaImediato : Tarefa
    {
        public override TipoAgendamentoEnum TipoAgendamento => TipoAgendamentoEnum.UnicoImediato;
        public TarefaUnicaImediato(IRestService restService) : base(restService){}
        public override Task Agendar(Agendamento agendamento)
        {
            var titulo = GetTitulo(agendamento);

            NovaTarefaImediata.Executar(() => _restService.Execute(titulo, agendamento));

            return Task.CompletedTask;
        }
    }
}
