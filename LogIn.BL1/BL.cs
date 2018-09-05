using System.Collections.Generic;
using LogIn.DAL;

namespace LogIn.BL1
{
    public class BL
    {
        public string CheckNew(object user)
        {
            var pb = (User)user;
            var CheckNewUser = new DBCon();
            var UsersLogins = new List<string>();
            foreach (var z in CheckNewUser.FindUser())
            {
                UsersLogins.Add(z.Login);
            }
            string login = UsersLogins.Find(x => x == pb.Login);
            if (login == null)
            {
                return (CheckNewUser.Insert(pb));
            }
            else
            {
                return ("Пользователь с таким логином уже существует");
            }


        }
        public string Check(object user)
        {
            var pb = (User)user;
            var CheckUser = new DBCon();
            var UsersLogins = new List<string>();
            foreach (var z in CheckUser.FindUser())
            {
                UsersLogins.Add(z.Login);
            }
            string login = UsersLogins.Find(x => x == pb.Login);
            if (login == null)
            {
                return ("Пользователь с таким логином не существует");
            }
            else
            {
                var CheckedUser = CheckUser.FindUser().Find(x => x.Login == pb.Login);
                if (CheckedUser.Password == pb.Password)
                {

                    return ("Пароль верный");
                }
                else
                {
                    return ("Пароль не верный");
                }
            }

        }
    }
}
