using Hangfire;
using Hangfire.SqlServer;

namespace hangfire.api.Configurations
{
    public static class HangFireConfiguration
    {
        public static void AddHangFireConfiguration(this IServiceCollection services, IConfiguration app)
        {
            services.AddHangfire(configuration => configuration
                                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                                    .UseSimpleAssemblyNameTypeSerializer()
                                    .UseRecommendedSerializerSettings()
                                    .UseSqlServerStorage(
                                        app.GetConnectionString("AgendamentoDb"), new SqlServerStorageOptions
                                        {
                                            TransactionTimeout = TimeSpan.FromMinutes(60),
                                            CommandTimeout = TimeSpan.FromMinutes(60),
                                            CommandBatchMaxTimeout = TimeSpan.FromMinutes(60),
                                            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(60),
                                            QueuePollInterval = TimeSpan.Zero,
                                            UseRecommendedIsolationLevel = true,
                                            DisableGlobalLocks = true
                                        }
                                    )
                                );
            services.AddHangfireServer();
        }
    }
}
