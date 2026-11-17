using MySql.Data.MySqlClient;

namespace HairSalonManagement
{
    public static class DBManager
    {        
        private const string ConnectionString =
            "Server=127.0.0.1;Port=3306;Database=Sample;" +
            "Uid=root;Pwd=1234;CharSet=utf8mb4;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
