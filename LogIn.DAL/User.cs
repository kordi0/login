using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn.DAL
{
    public class User
    {
        public string Name;
        public int Age;
        public string Login;
        public string Password;

        public User(string name, int age, string login, string password)
        {
            Name = name;
            Age = age;
            Login = login;
            Password = password;
        }
    }
}
