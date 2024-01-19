using notenverwaltung.backend.Modal;

namespace notenverwaltung.backend.Adapter
{
    public interface IDatabaseAdapter
    {
        void OpenConnection(string ConnectionString);
        void CloseConnection();
        void CreateNewUser(User user);
        List<List<String>> GetUsers();

        List<List<String>> GetStudent();

        void GetTeacher()
        {

        }
        void ExecuteQuery(string query);
    }
}

