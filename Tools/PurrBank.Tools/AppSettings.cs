namespace PurrBank.Tools
{
    public static class AppSettings
    {
        public static MySqlConnectionString ConnectionString { get; set; }
        public static MongoSettings MongoSettings { get; set; }
    }

    public class MongoSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string UsersCollectionName { get; set; }
    }

    public class MySqlConnectionString
    {
        public string MySql { get; set; }
    }
}
