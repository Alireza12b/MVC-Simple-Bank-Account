namespace BankAccountManagement.Models
{
    public interface IUserRepository
    {
        bool Login(string nationalId, string phone);
        public List<Account> ShowAccount(string nationalId);
        public void Deposit(string nationalId, int amount, string description);
        public bool Withdraw(string nationalId, int amount, string description);
    }
}
