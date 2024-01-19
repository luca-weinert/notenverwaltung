using MySqlConnector;
using notenverwaltung.backend.Modal;

namespace notenverwaltung.backend.Adapter
{
    public class MySqlAdapter : IDatabaseAdapter
    {
        private MySqlConnection _conn;

        public MySqlAdapter()
        {
        }

        public void OpenConnection(string connString)
        {
            try
            {
                _conn = new MySqlConnection(connString);
                _conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void CloseConnection()
        {
            _conn.Close();
        }

        public void CreateNewUser(User user)
        {
            MySqlCommand sqlCmd =
                new MySqlCommand(
                    $"INSERT INTO Users (FirstName, LastName, BirthDate) VALUES('{user.firstname}','{user.lastName}','{user.birthdate}');",
                    _conn);
            try
            {
                sqlCmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public List<List<String>> GetUsers()
        {
            List<List<string>> users = new List<List<String>>();

            MySqlCommand sqlCmd = new MySqlCommand("SELECT * FROM Users;", _conn);
            MySqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                List<string> user = new List<string>
                {
                    reader.GetInt32(0).ToString(),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3).ToString()
                };
                users.Add(user);
            }

            reader.Close();
            return users;
        }

        public void GetTeacher()
        {
        }

        public List<List<String>> GetStudent()
        {
            List<List<string>> studens = new List<List<String>>();

            MySqlCommand sqlCmd = new MySqlCommand("SELECT * FROM Students;", this._conn);
            MySqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                List<string> user = new List<string>
                {
                    reader.GetInt32(0).ToString(),
                    reader.GetInt32(1).ToString()
                };
                studens.Add(user);
            }

            reader.Close();
            return studens;
        }

        public void ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }
    };
};