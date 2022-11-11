using System.Net;
using System.Net.Http.Headers;
using hangfire.api.Models;
using Newtonsoft.Json;

namespace hangfire.api.Services
{
    public interface IHttpRestClientService
    {
        public void SetIsAsync(bool isAsync);

        Task<string> GetStringAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer");
        Task<string> GetAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer");
        Task<string> PostAsync<TInput>(string uri, TInput item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer");
        Task<string> DeleteAsync(string uri, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer");

        Task<TResponse> PutAsync<TInput, TResponse>(string uri, TInput item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer");
        Task<string> PutAsync<TInput>(string uri, TInput item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer");
    }
    public class HttpRestClientService : IHttpRestClientService
    {
        private readonly HttpClient _client;
        private bool _isAsync { get; set; }
        private readonly string _asyncMessage = "Executado assincronicamente.";

        public HttpRestClientService(HttpClient client)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            _client = new HttpClient(clientHandler); 
            _client.Timeout = TimeSpan.FromMinutes(60);
        }

        public void SetIsAsync(bool isAsync)
        {
            _isAsync = isAsync;
        }

        public async Task<string> GetStringAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            if (authorizationToken != null)
                requestMessage.Headers.Authorization = GetAuthorization(authorizationMethod, authorizationToken);

            requestMessage.Headers.Add("x-process", "jobs");

            if (_isAsync)
            {
                _client.SendAsync(requestMessage);

                return await Task.FromResult(_asyncMessage);
            }

            var response = await _client.SendAsync(requestMessage);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            return await GetStringAsync(uri, authorizationToken, authorizationMethod);
        }

        public async Task<string> DeleteAsync(string uri, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            if (authorizationToken != null)
                requestMessage.Headers.Authorization = GetAuthorization(authorizationMethod, authorizationToken);

            if (requestId != null)
                requestMessage.Headers.Add("x-requestid", requestId);

            requestMessage.Headers.Add("x-process", "jobs");

            if (_isAsync)
            {
                _client.SendAsync(requestMessage);
                return await Task.FromResult(_asyncMessage);
            }

            var response = await _client.SendAsync(requestMessage);

            var result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.InternalServerError)
                throw new HttpRequestException(result);

            return result;
        }

        public async Task<TResponse> PutAsync<TInput, TResponse>(string uri, TInput item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            return await DoPostPutAsync<TInput, TResponse>(HttpMethod.Put, uri, item, authorizationToken, requestId, authorizationMethod);
        }

        public async Task<string> PutAsync<TInput>(string uri, TInput item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            return await DoPostPutAsync(HttpMethod.Put, uri, item, authorizationToken, requestId, authorizationMethod);
        }

        public async Task<string> PostAsync<TInput>(string uri, TInput item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            return await DoPostPutAsync(HttpMethod.Post, uri, item, authorizationToken, requestId, authorizationMethod);
        }

        private async Task<TResponse> DoPostPutAsync<TInput, TResponse>(HttpMethod method, string uri, TInput item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            var content = await DoPostPutAsync(method, uri, item, authorizationToken, requestId, authorizationMethod);

            return JsonConvert.DeserializeObject<TResponse>(content);
        }

        private async Task<string> DoPostPutAsync<TInput>(HttpMethod method, string uri, TInput item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            if (method != HttpMethod.Post && method != HttpMethod.Put)
                throw new ArgumentException("Value must be either post or put.", nameof(method));

            var requestMessage = new HttpRequestMessage(method, uri);

            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(JsonConvert.DeserializeObject<object>(Convert.ToString(item))), System.Text.Encoding.UTF8, "application/json");

            if (authorizationToken != null)
                requestMessage.Headers.Authorization = GetAuthorization(authorizationMethod, authorizationToken);

            if (requestId != null)
                requestMessage.Headers.Add("x-requestid", requestId);

            requestMessage.Headers.Add("x-process", "jobs");

            if (_isAsync)
            {
                _client.SendAsync(requestMessage);

                return await Task.FromResult(_asyncMessage);
            }

            var response = await _client.SendAsync(requestMessage);

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) return result;

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new HttpRequestException($"Requisição não autorizada { response.RequestMessage.RequestUri}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new HttpRequestException($"Url não encontrada: { response.RequestMessage.RequestUri}");

            var content = await response.Content.ReadAsStringAsync();

            throw new HttpRequestException($"Erro ao fazer requsição. URL: {response.RequestMessage.RequestUri} Body: {content}");
        }

        private static AuthenticationHeaderValue GetAuthorization(string authorizationMethod, string authorizationToken)
        {
            if (!authorizationToken.StartsWith(authorizationMethod)) return new AuthenticationHeaderValue(authorizationMethod, authorizationToken);

            var token = authorizationToken.Split(' ');
            return new AuthenticationHeaderValue(authorizationMethod, token[1]);
        }


        public async Task<Result<TResponse>> PutResultAsync<TInput, TResponse>(string uri, TInput item, string authorizationToken = null, string requestId = null, string authorizationMethod = "Bearer")
        {
            try
            {
                var result = await PutAsync<TInput, TResponse>(uri, item, authorizationToken, requestId, authorizationMethod);
                return Result<TResponse>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<TResponse>.Fail(ex.Message);
            }
        }
    }
}
