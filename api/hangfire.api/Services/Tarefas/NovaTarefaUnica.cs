using Hangfire;
using System.Linq.Expressions;

namespace hangfire.api.Services.Tarefas
{
    public static class NovaTarefaUnica
    {
        public static void Executar(Expression<Action> metodo, DateTimeOffset dateTimeOffset)
        {
            BackgroundJob.Schedule(metodo, dateTimeOffset);
        }
    }
}