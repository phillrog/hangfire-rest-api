using hangfire.api.Models;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace hangfire.api.Controllers
{
    public class TarefaController : ControllerBase
    {
        [HttpPost("Agendar")]
        public Task<IActionResult> Agendar([FromBody] Agendamento agendamento)
        {
            var dataAgendamento = agendamento.DataAgendamento;

            agendamento.DataInicio = DateTime.Now;

            var minutes = (dataAgendamento - DateTime.Now).TotalMinutes;

            var dateTimeOffset = DateTimeOffset.Now.AddMinutes(minutes);

            //var jobId = BackgroundJob.Schedule(() => REQUEST, dateTimeOffset);

            return Ok();
        }
    }
}
