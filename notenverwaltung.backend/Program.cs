using notenverwaltung.backend.Adapter;
using notenverwaltung.backend.Repositories;

namespace notenverwaltung.backend
{
    class Programm
    {
        public static void GetAllGradesForStudent(int StudentID)
        {
            // 
            // 
        }

        public static void Main(string[] args)
        {
            IDatabaseAdapter mysqlAdapter = new MySqlAdapter();
            Repository repository = new Repository(mysqlAdapter);
            repository.OpenConnection();

            // GetAllGradesForStudent(1);
            var users = repository.GetUser();
            
            Console.WriteLine(users[0].firstname);
            // User user = new User("test", "user", "1701421323");
            // repository.SaveUsers(user);

            // repository.GetStudent();
            // repository.CloseConnection();
            // User user = repository.GetUser();
        }
    };
}

