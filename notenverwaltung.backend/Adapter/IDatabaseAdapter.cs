using Notenverwaltung.Backend.Modal;

namespace Notenverwaltung.Backend.Adapter
{
    public interface IDatabaseAdapter
    {
        void OpenConnection();
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

