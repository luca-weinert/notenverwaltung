using notenverwaltung.backend.Adapter;
using notenverwaltung.backend.Modal;

namespace notenverwaltung.backend.Repositories
{
    public class Repository
    {
        private readonly IDatabaseAdapter _databaseAdapter;

        public Repository(IDatabaseAdapter databaseAdapter)
        {
            _databaseAdapter = databaseAdapter;
        }

        public void OpenConnection()
        {
            _databaseAdapter.OpenConnection(
                "Server=localhost;Port=3306;User=luca;Password=test123#;Database=notenverwaltung;SSL Mode=none;AllowPublicKeyRetrieval=true");
        }

        public void CloseConnection()
        {
            _databaseAdapter.CloseConnection();
        }

        public void SaveUsers(User user)
        {
            _databaseAdapter.CreateNewUser(user);
        }

        public void GetStudent()
        {
            List<List<String>> students = _databaseAdapter.GetStudent();
            //TODO: convert student list to student object
        }

        public void GetTeacher()
        {
            _databaseAdapter.GetTeacher();
        }

        public List<User> GetUser()
        {
            var usersRaw = _databaseAdapter.GetUsers();

            List<User> users = new List<User>();

            foreach (var user in usersRaw)
            {
                users.Add(new User()
                {
                    id = user[0],
                    firstname = user[1],
                    lastName = user[2],
                    birthdate = user[3]
                });
            }
            
            return users;
        }
    }
}