namespace Learn_DesignPatterns.Creational.Singleton
{
    internal class SingletonExecutor
    {
        public void Run()
        {
            DbConnection[] conns = new DbConnection[5];
            for (int i = 0; i < conns.Length; ++i)
            {
                conns[i] = DbConnection.GetInstance("connection_string");
            }
            for (int i = 0; i < conns.Length; ++i)
            {
                Console.WriteLine($"Hashcode of object at {i}: {conns[i].GetHashCode()}");
            }
        }

        public void RunThreadSafe()
        {
            Thread[] ts = new Thread[5];

            for(int i = 0; i < ts.Length; ++i)
            {
                ts[i] = new Thread(CreateInstance);
                ts[i].Name = $"T-{i}";
                ts[i].Start();
            }

            for (int i = 0; i < ts.Length; ++i)
            {
                ts[i].Join();
            }
        }

        private void CreateInstance()
        {
            DbConnectionThreadSafe obj = DbConnectionThreadSafe.GetInstance("connection_string");
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} - object hashcode: {obj.GetHashCode()}");
        }
    }
}
