using hangfire.api.Services;
using hangfire.api.Services.Tarefas;

namespace hangfire.api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAgendadorService, AgendadorService>();
            services.AddScoped<IRestService, RestService>();
            services.AddHttpClient<IHttpRestClientService, HttpRestClientService>();

            services.AddScoped<Tarefa, TarefaUnicaImediato>();
            services.AddScoped<Tarefa, TarefaUnica>();
            services.AddScoped<Tarefa, TarefaDiario>();
        }
    }
}
