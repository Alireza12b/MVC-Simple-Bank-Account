namespace BankAccountManagement.Models
{
    public class Log
    {
        public DateTime timestamp { get; private set; }
        public string Url { get; private set; }
        public int resultStatusCode { get; set; }

        public Log(string url)
        {
            timestamp = DateTime.Now;
            Url = url;
        }

        public override string ToString()
        {
            return Url + " | " + timestamp + " | " + resultStatusCode.ToString() + "\n\n------------------------------------------------------------------------------------------------------\n";
        }
    }
}
