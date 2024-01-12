using Notenverwaltung.Backend.Adapter;
using Notenverwaltung.Backend.Modal;

namespace Notenverwaltung.Backend
{
    public class Repository
    {
        private IDatabaseAdapter adapter;

        public Repository(IDatabaseAdapter adapter)
        {
            this.adapter = adapter;
        }

        public void OpenConnection()
        {
            adapter.OpenConnection();
        }

        public void CloseConnection()
        {
            adapter.CloseConnection();
        }

        public void SaveUsers(User user)
        {
            adapter.CreateNewUser(user);
        }

        public void GetStudent()
        {
            List<List<String>> students = adapter.GetStudent();
            //TODO: convert student list to student object
        }

        public void GetTeache()
        {
            adapter.GetTeacher();
        }

        public void GetUser()
        {
            List<List<String>> users = adapter.GetUsers();
            //TODO: convert user list to user obeject
        }
    }
}