namespace BankAccountManagement.Models
{
    public static class DataBase
    {
        public static List<User> user = new List<User>()
        {
            new User(){Id = 1 ,Name = "Ali" , Fname = "Alavi" ,Phone ="01" ,NationalId = "10"},
            new User(){Id = 2 ,Name = "Reza" , Fname = "Razavi" ,Phone ="02" ,NationalId = "20"},
            new User(){Id = 3 ,Name = "Amin" , Fname = "Amini" ,Phone ="03" ,NationalId = "30"},
            new User(){Id = 4 ,Name = "Amir" , Fname = "Amiri" ,Phone ="04" ,NationalId = "40"}
        };

        public static List<Account> account = new List<Account>()
        {
            new Account(){AccId = 1 ,AccName = "Ali Alavi" ,Debit = 5000 , Credit = 10000 ,TransactionDate = DateTime.Parse("1/2/2022")},
            new Account(){AccId = 2 ,AccName = "Reza Razavi" ,Debit = 4000 , Credit = 20000 ,TransactionDate = DateTime.Parse("3/4/2022")},
            new Account(){AccId = 3 ,AccName = "Amin Amini" ,Debit = 3000 , Credit = 30000 ,TransactionDate = DateTime.Parse("4/5/2022")},
            new Account(){AccId = 4 ,AccName = "Amir Amiri" ,Debit = 2000 , Credit = 40000 ,TransactionDate = DateTime.Parse("6/7/2022")},
        };

        public static List<Log> Logs = new List<Log>() { };

    }
}
