using hangfire.api.Models;

namespace hangfire.api.Services
{
    public interface IAgendadorService
    {
        Task AgendarTarefaUnicaImediata(Agendamento agendamento);
    }

    public class AgendadorService : IAgendadorService
    {
        private readonly HttpContext _httpContext;
        
        public Task AgendarTarefaUnicaImediata(Agendamento agendamento)
        {
            var dataAgendamento = agendamento.DataAgendamento;

            agendamento.DataInicio = DateTime.Now;

            var minutes = (dataAgendamento - DateTime.Now).TotalMinutes;

            var dateTimeOffset = DateTimeOffset.Now.AddMinutes(minutes);

            //var jobId = BackgroundJob.Schedule(() => REQUEST, dateTimeOffset);
            return Task.CompletedTask;
        }
        
    }

}
