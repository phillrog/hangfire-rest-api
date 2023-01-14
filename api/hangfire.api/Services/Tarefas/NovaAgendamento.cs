using Hangfire;
using System.Linq.Expressions;

namespace hangfire.api.Services.Tarefas
{
    public static class NovaAgendamento
    {
        public static void Executar(Expression<Action> metodo, string cron, string id)
        {
            RecurringJob.AddOrUpdate(id,
            metodo,
            cron,
            TimeZoneInfo.Local);
        }
    }
}