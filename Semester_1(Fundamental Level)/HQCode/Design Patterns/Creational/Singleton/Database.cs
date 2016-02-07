namespace Singleton
{
    using System;

    public class Database
    {
        private static Database instance;

        private Database()
        {
            
        }

        public Database Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }

                return instance;
            }
        }

        public object Query(string query)
        {
            Console.WriteLine(query);

            return default(object);
        }
    }
}