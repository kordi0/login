using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LogIn.DAL
{
    public class DBCon
    {

        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
        public string Try()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return ($"Подключение: {connection.State}");
            }

        }
        public string Insert(object user)
        {
            var pb = (User)user;
            string sqlInsert = $"INSERT INTO Users (Name, Age, Login, Pass) VALUES ('{pb.Name}', {pb.Age}, '{pb.Login}', '{pb.Password}')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlInsert, connection);
                int number = command.ExecuteNonQuery();
                return ($"Добавлено объектов: {number}");

            }

        }
        public List<User> FindUser()
        {

            List<User> users = new List<User>();
            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {


                    while (reader.Read()) // построчно считываем данные
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int age = reader.GetInt32(2);
                        string login = reader.GetString(3);
                        string pass = reader.GetString(4);
                        users.Add(new User(name, age, login, pass));
                    }
                    reader.Close();
                    return (users);
                }
                else
                {
                    return (users);
                }
            }
        }

    }
}
