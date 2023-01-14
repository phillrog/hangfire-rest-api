using hangfire.api.Models;
using hangfire.api.Services.Tarefas;

namespace hangfire.api.Services
{
    public interface IAgendadorService
    {
        Task Agendar(Agendamento agendamento);
    }

    public class AgendadorService : IAgendadorService
    {
        private readonly IEnumerable<Tarefa> _tarefas;

        public AgendadorService(IEnumerable<Tarefa> tarefas)
        {
            _tarefas = tarefas;
        }
        
        public async Task Agendar(Agendamento agendamento)
        {
            try
            {
                var tarefa = _tarefas.Where(t => t.TipoAgendamento == agendamento.TipoAgendamento).First();
                await tarefa.Agendar(agendamento);
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Tipo agendamento não foi encontrado") ;
            }            

            return;
        }
        
    }

}
