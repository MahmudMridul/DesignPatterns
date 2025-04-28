namespace Learn_DesignPatterns.Creational.Singleton
{
    internal class DbConnection
    {
        private static DbConnection _instance = null!;
        private string _connectionString = string.Empty;

        private DbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static DbConnection GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new DbConnection(connectionString);
            }
            return _instance;
        }
    }
}
