using System.Net.Http.Json;
using BankBlazor.Client.Models;

namespace BankBlazor.Client.Services;
    public class AccountService
    {
        private readonly HttpClient _http;
        public AccountService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<AccountDto>> GetAccountsByCustomerIdAsync(int customerId)
        {
            try
            {
                var response = await _http.GetAsync($"api/customers/{customerId}/accounts");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<AccountDto>>() ?? new();
                }
                return new();
            }
            catch
            {
                return new();
            }
        }

        public async Task<AccountDto?> DepositAsync(DepositRequest req)
        {
            var response = await _http.PostAsJsonAsync("api/transactions/deposit", req);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AccountDto>();
        }

        public async Task<AccountDto?> WithdrawAsync(WithdrawRequest req)
        {
            var response = await _http.PostAsJsonAsync("api/transactions/withdraw", req);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AccountDto>();
        }

        public async Task<bool> TransferAsync(TransferRequest req)
        {
            var response = await _http.PostAsJsonAsync("api/transactions/transfer", req);
            return response.IsSuccessStatusCode;
        }
    }
