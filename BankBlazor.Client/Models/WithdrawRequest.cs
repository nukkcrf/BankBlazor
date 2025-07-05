namespace BankBlazor.Client.Models
{
    public class WithdrawRequest
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
    }
} 