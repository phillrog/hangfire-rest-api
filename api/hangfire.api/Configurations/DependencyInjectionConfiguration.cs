using hangfire.api.Services;

namespace hangfire.api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAgendadorService, AgendadorService>();
            services.AddScoped<IRestService, RestService>();
        }
    }
}
