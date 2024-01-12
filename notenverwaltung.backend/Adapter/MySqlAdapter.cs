using Notenverwaltung.Backend.Modal;

namespace Notenverwaltung.Backend.Adapter.MySql
{
    using Notenverwaltung.Backend.Adapter;
    using System;
    using System.Collections.Generic;
    using MySqlConnector;

    public class MySqlAdapter : IDatabaseAdapter
    {
        private MySqlConnection conn;

        public void OpenConnection()
        {
            string connString = "Server=localhost;Port=3306;User=luca;Password=test123#;Database=notenverwaltung;SSL Mode=none;AllowPublicKeyRetrieval=true";
            this.conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                // Hier solltest du die Ausnahme entsprechend behandeln oder loggen
                Console.WriteLine(e);
            }
        }

        public void CloseConnection()
        {
            this.conn.Close();
        }

        public void CreateNewUser(User user)
        {
            MySqlCommand sqlCmd = new MySqlCommand($"INSERT INTO Users (FirstName, LastName, BirthDate) VALUES('{user.firstname}','{user.lastName}','{user.birthdate}');", this.conn);
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

            MySqlCommand sqlCmd = new MySqlCommand("SELECT * FROM Users;", this.conn);
            MySqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                List<string> user = new List<string>
                    {
                        reader.GetInt32(0).ToString(),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetDateTime(3).ToString()
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

            MySqlCommand sqlCmd = new MySqlCommand("SELECT * FROM Students;", this.conn);
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