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
        
        public void GetAllTeachers()
        {
            _databaseAdapter.GetTeacher();
        }
        
        public List<Student> GetAllStudents()
        {
            var studentsRaw = _databaseAdapter.GetAllStudents();

            List<Student> students = new List<Student>();
          
            foreach (var student in studentsRaw)
            {
                students.Add(new Student()
                {
                    StudentID = student[0],
                    UserID = student[1]
                });
            }

            return students;
        }

        public List<User> GetAllUsers()
        {
            var usersRaw = _databaseAdapter.GetAllUsers();

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