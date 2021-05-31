using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MMTShop.Business.Interfaces;
using MMTShop.Common.CustomExceptions;
using Newtonsoft.Json;

namespace MMTShop.Business.Components
{
    public class ApiGateway : IApiGateway
    {
        private HttpClient _client;

        public ApiGateway()
        {
            _client = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string url)
        {
            try
            {
                var result = await _client.GetAsync(url);
                return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {
                throw new ApiGatewayException($"Error occured while retrieving information from the following endpoint - {url}", e);
            }
        }
    }
}
