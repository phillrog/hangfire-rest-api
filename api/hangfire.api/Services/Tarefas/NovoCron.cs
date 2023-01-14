using hangfire.api.Enums;
using hangfire.api.Models;
using Hangfire;

namespace hangfire.api.Services.Tarefas
{
    public static class NovoCron
    {
        public static string Criar(CronEnum cronEnum, ITipoCron tipoCron )
        {
            var retorno = string.Empty;

            switch(cronEnum)
            {
                case CronEnum.Diario: { retorno = Cron.Daily(((Diario)tipoCron).Hora, ((Diario)tipoCron).Minuto); break; }
            }
            return retorno;
        }
    }
}