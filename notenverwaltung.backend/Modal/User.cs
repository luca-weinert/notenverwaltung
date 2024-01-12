namespace Notenverwaltung.Backend.Modal
{
    using System;
    public class User
    {
        public string firstname { get; private set; }
        public string lastName { get; private set; }
        public string birthdate { get; private set; }

        public User(string firstname, string lastName, string birthdate)
        {
            this.firstname = firstname;
            this.lastName = lastName;
            this.birthdate = birthdate;
        }
    }
}


