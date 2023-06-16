using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RegisteredUser
    {
        List<User> users = new List<User>();
        private RegisteredUser() {
            addUser(new User("Tes", "Tes"));
        }

        private static RegisteredUser _instance;
        public static RegisteredUser getInstance()
        {
            if (_instance == null)
            {
                _instance = new RegisteredUser();
            }
            return _instance;
        }

        public void addUser(User user) { users.Add(user); }

        public List<User> getUsers() { return users;}
    }
}
