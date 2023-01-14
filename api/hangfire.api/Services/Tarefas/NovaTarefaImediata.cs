using Hangfire;
using System.Linq.Expressions;

namespace hangfire.api.Services.Tarefas
{
    public static class NovaTarefaImediata
    {
        public static void Executar(Expression<Action> metodo)
        {
            BackgroundJob.Enqueue(metodo);
        }
    }
}