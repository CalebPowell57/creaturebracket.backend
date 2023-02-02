using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ExternalService
{
    class BaseResponse<T>
    {
        public long Count { get; set; }
        public IEnumerable<T> Results { get; set; }
    }

    public abstract class BaseService
    {
        protected HttpClient _httpClient { get; private set; }

        protected void SetNoun(string noun)
        {
            _httpClient.BaseAddress = new Uri($"{_baseUrl}{noun}");
        }

        private string _baseUrl;

        public BaseService(string baseUrl)
        {
            _baseUrl = baseUrl;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
            };
        }

        protected async Task<IEnumerable<T>> GetList<T>(string routeModifier = "")
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<T>>(routeModifier);

            return response;
        }

        protected async Task<T> Get<T>(string routeModifier = "")
        {
            if (!routeModifier.StartsWith("/"))
            {
                routeModifier = $"/{routeModifier}";
            }

            var url = $"{_httpClient.BaseAddress}/{routeModifier}";

            var json = await _httpClient.GetStringAsync(url);

            var response = JsonConvert.DeserializeObject<T>(json);

            //var response = await _httpClient.GetFromJsonAsync<T>(routeModifier);

            return response;
        }
    }
}