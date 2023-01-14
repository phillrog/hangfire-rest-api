using hangfire.api.Models;
using hangfire.api.ViewModels;
using Hangfire.Storage;
using Hangfire.Storage.Monitoring;

namespace hangfire.api.Factories
{
    public static class AgendamentoModelFactory
    {
        public static AgendamentoViewModel ToModel(string JobId, ScheduledJobDto schedule)
        {
            var job = schedule.Job;

            var split2 = job.Args[0].ToString().Split(':')[1].Split('-');
            var body = (Agendamento)job.Args[1];

            return new AgendamentoViewModel
            {
                Id = body.Id,
                Nome = body.Nome,
                NomeCompleto = job.Args[0].ToString(),
                Url = body.Url,
                Body = body.Body,
                Agendamento = split2[0].Trim(),
                DataAgendamento = body.DataAgendamento,
                TipoAgendamento = body.TipoAgendamento,
                TipoService = body.TipoService,
                TipoVerbo = body.TipoVerbo,
                Service = split2[1].Trim(),
                Verbo = split2[2].Trim(),
                DataInicio = body.DataInicio,
                Async = body.Async,
                JobId = JobId
            };
        }

        public static AgendamentoViewModel ToModel(RecurringJobDto recurring)
        {
            var job = recurring.Job;

            var split2 = job.Args[0].ToString().Split(':')[1].Split('-');
            var body = (Agendamento)job.Args[1];

            return new AgendamentoViewModel
            {
                Id = body.Id,
                Nome = body.Nome,
                NomeCompleto = job.Args[0].ToString(),
                Url = body.Url,
                Body = body.Body,
                Agendamento = split2[0].Trim(),
                DataAgendamento = body.DataAgendamento,
                TipoAgendamento = body.TipoAgendamento,
                TipoService = body.TipoService,
                TipoVerbo = body.TipoVerbo,
                Service = split2[1].Trim(),
                Verbo = split2[2].Trim(),
                DataInicio = body.DataInicio,
                Async = body.Async,
                JobId = recurring.Id
            };
        }
    }
}
