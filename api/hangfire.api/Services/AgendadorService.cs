using hangfire.api.Enums;
using hangfire.api.Factories;
using hangfire.api.Models;
using hangfire.api.Services.Tarefas;
using hangfire.api.ViewModels;
using Hangfire;
using Hangfire.Storage;
using Hangfire.Storage.Monitoring;

namespace hangfire.api.Services
{
    public interface IAgendadorService
    {
        Task Agendar(Agendamento agendamento);
        Task<List<AgendamentoViewModel>> ListarTarefasAgendadas();
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
                throw new Exception("Tipo agendamento não foi encontrado");
            }

            return;
        }

        public Task<List<AgendamentoViewModel>> ListarTarefasAgendadas()
        {
            var api = JobStorage.Current.GetMonitoringApi();
            var listaImediatos = new List<AgendamentoViewModel>();
            var listaAgendados = new List<AgendamentoViewModel>();

            var scheduledJobs = api.ScheduledJobs(0, 100);
            var recurringJobs = JobStorage.Current.GetConnection().GetRecurringJobs();

            scheduledJobs.ForEach(p => listaImediatos.Add(AgendamentoModelFactory.ToModel(p.Key, p.Value)));
            recurringJobs.ForEach(p => listaAgendados.Add(AgendamentoModelFactory.ToModel(p)));

            listaAgendados.AddRange(listaImediatos.Where(p => (int)p.TipoAgendamento == (int)TipoAgendamentoEnum.Unico && listaAgendados.All(l => l.Id != p.Id)).ToList());
            return Task.FromResult(listaAgendados);
        }
    }
}
