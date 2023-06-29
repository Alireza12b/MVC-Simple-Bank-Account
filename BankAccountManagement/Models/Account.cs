namespace BankAccountManagement.Models
{
    public class Account
    {
        public int AccId { get; set; }
        public string AccName { get; set; }
        public float Debit { get; set; }
        public float Credit { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
    }
}
