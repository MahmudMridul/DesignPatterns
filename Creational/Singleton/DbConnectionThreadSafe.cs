namespace Learn_DesignPatterns.Creational.Singleton
{
    internal class DbConnectionThreadSafe
    {
        private static readonly Lazy<DbConnectionThreadSafe> _instance = null!;
        private static string _connectionString = string.Empty;

        static DbConnectionThreadSafe()
        {
            _instance = new Lazy<DbConnectionThreadSafe>(
                () => new DbConnectionThreadSafe(_connectionString),
                LazyThreadSafetyMode.ExecutionAndPublication
            );
        }

        private DbConnectionThreadSafe(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static DbConnectionThreadSafe GetInstance(string connectionString)
        {
            return _instance.Value;
        }
    }
}
