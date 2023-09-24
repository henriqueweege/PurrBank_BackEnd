namespace PurrBank.Tools
{
    public static class AppSettings
    {
        public static ConnectionString ConnectionString { get; set; }
    }

    public class ConnectionString
    {
        public string MySql { get; set; }
    }
}
