
using hangfire.api.Enums;
using hangfire.api.Models;
using System.ComponentModel;

namespace hangfire.api.Services
{
    public interface IRestService
    {
        string Execute(string titulo, Agendamento agendamento);

    }

    public class RestService : IRestService
    {
        private readonly IHttpRestClientService _httpRestClientService;

        public RestService(IHttpRestClientService httpClientService)
        {
            _httpRestClientService = httpClientService;
        }

        [DisplayName("{0}")]
        public string Execute(string titulo, Agendamento agendamento)
        {
            try
            {
                return Task.Run(async () => await Execute(agendamento)).Result;
            }
            catch (Exception ex)
            {
                
            }

            return String.Empty;
        }

        private async Task<string> Execute(Agendamento agendamento)
        {
            _httpRestClientService.SetIsAsync(agendamento.Async);
            return agendamento.TipoVerbo switch
            {
                TipoVerboEnum.Get => await GetUrl(agendamento),
                TipoVerboEnum.Post => await PostUrl(agendamento),
                TipoVerboEnum.Put => await PutUrl(agendamento),
                TipoVerboEnum.Delete => await DeleteUrl(agendamento),
                _ => await GetUrl(agendamento),
            };
        }

        protected async Task<string> GetUrl(Agendamento agendamento)
        {
            return await _httpRestClientService.GetAsync(agendamento.Url);
        }

        protected async Task<string> PostUrl(Agendamento agendamento)
        {
            return await _httpRestClientService.PostAsync(agendamento.Url, agendamento.Body);
        }

        protected async Task<string> PutUrl(Agendamento agendamento)
        {
            return await _httpRestClientService.PutAsync(agendamento.Url, agendamento.Body);
        }

        protected async Task<string> DeleteUrl(Agendamento agendamento)
        {
            return await _httpRestClientService.DeleteAsync(agendamento.Url);
        }
    }
}
