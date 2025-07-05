using System.Net.Http.Json;
using BankBlazor.Client.Models;

namespace BankBlazor.Client.Services
{
    public class TransactionService
    {
        private readonly HttpClient _http;
        public TransactionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TransactionDto>> GetTransactionsByAccountIdAsync(int accountId)
        {
            try
            {
                var response = await _http.GetAsync($"api/accounts/{accountId}/transactions");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<TransactionDto>>() ?? new();
                }
                return new();
            }
            catch
            {
                return new();
            }
        }
    }
} 