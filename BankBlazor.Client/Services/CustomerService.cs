using System.Net.Http.Json;
using BankBlazor.Client.Models;

namespace BankBlazor.Client.Services
{
    public class CustomerService
    {
        private readonly HttpClient _http;
        public CustomerService(HttpClient http)
        {
            _http = http;
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(int customerId)
        {
            try
            {
                var response = await _http.GetAsync($"api/customers/{customerId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CustomerDto>();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
} 