namespace BankBlazor.Client.Models
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public string Frequency { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public decimal Balance { get; set; }
    }
} 