using Sales.BlazorClient.Exceptions;
using Sales.DTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sales.BlazorClient.Services
{
    public class SalesApiClient
    {
        readonly HttpClient Client;
        public SalesApiClient(HttpClient client) => Client = client;

        public async Task<int> CreateOrder(CreateOrderDto order)
        {
            int orderId = 0;
            using HttpResponseMessage response = await Client.PostAsJsonAsync("create", order);
            if (response.IsSuccessStatusCode)
            {
                orderId = await response.Content.ReadFromJsonAsync<int>();
            }
            else
            {
                throw (await GetException(response));
            }
            return orderId;
        }

        private async Task<HttpCustomException> GetException(HttpResponseMessage response)
        {
            JsonElement jsonContent = await response.Content.ReadFromJsonAsync<JsonElement>();
            ProblemsDetails problems = JsonSerializer.Deserialize<ProblemsDetails>(jsonContent.GetRawText()
                , new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (jsonContent.TryGetProperty("invalid-params", out JsonElement invalidParams))
            {
                problems.InvalidParams = JsonSerializer.Deserialize<Dictionary<string, string>>(invalidParams.GetRawText());
            }
            return new HttpCustomException(problems);
        }
    }
}
