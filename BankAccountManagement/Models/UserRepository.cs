using System.Numerics;

namespace BankAccountManagement.Models
{
    public class UserRepository : IUserRepository
    {
        public bool Login(string nationalId, string phone)
        {
            var validUser = DataBase.user.Find(u => u.NationalId == nationalId && u.Phone == phone);
            if (validUser != null)
            {
                return true;
            }
            else { return false; }
        }

        public List<Account> ShowAccount(string nationalId)
        {
            var validUser = DataBase.user.Find(u => u.NationalId == nationalId);
            var userAcc = DataBase.account.Where(a => a.AccId == validUser.Id).ToList();
            return userAcc;
        }

        public void Deposit(string nationalId, int amount, string description)
        {
            var validUser = DataBase.user.Find(u => u.NationalId == nationalId);
            var userAcc = DataBase.account.Find(a => a.AccId == validUser.Id);

            float tempAmount;
            if (amount <= userAcc.Debit)
            {
                userAcc.Debit -= amount;
                userAcc.Description = description;
                userAcc.TransactionDate = DateTime.Now;
            }
            else
            {
                tempAmount = amount - userAcc.Debit;
                userAcc.Debit = 0;
                userAcc.Credit += tempAmount;
                userAcc.Description = description;
                userAcc.TransactionDate = DateTime.Now;
            }
        }

        public bool Withdraw(string nationalId, int amount, string description)
        {
            var validUser = DataBase.user.Find(u => u.NationalId == nationalId);
            var userAcc = DataBase.account.Find(a => a.AccId == validUser.Id);

            if (amount > userAcc.Credit)
            {
                return false;
            }
            else
            {
                userAcc.Description = description;
                userAcc.TransactionDate = DateTime.Now;
                userAcc.Credit -= amount;
                return true;
            }
        }
    }
}
