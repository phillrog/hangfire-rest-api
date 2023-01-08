using hangfire.api.Enums;
using hangfire.api.Extensions;
using hangfire.api.Models;
using hangfire.api.Services;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace hangfire.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly IAgendadorService _agendadorService;

        public TarefaController(IAgendadorService agendadorService)
        {
            _agendadorService = agendadorService;
        }

        [HttpPost("Agendar")]
        public async Task<IActionResult> Agendar(Agendamento agendamento)
        {
            if (agendamento == null) return BadRequest("Agendamento inválido");

            switch (agendamento.TipoAgendamento)
            {
                case TipoAgendamentoEnum.UnicoImediato: _agendadorService.AgendarTarefaUnicaImediata(agendamento); break;
            }

            var tiposAgendamentos = typeof(TipoAgendamentoEnum).ToEnumList();
            var tipoAgendamento = tiposAgendamentos[(int)agendamento.TipoAgendamento];

            return Ok(new { sucesso = $"Agendamento '{tipoAgendamento}' de tarefa realizado com sucesso" });
        }
    }
}
