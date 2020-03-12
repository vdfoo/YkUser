using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using YkUser.Model;
using YkUser.Utility;

namespace YkUser.DAL
{
    public class UserDal
    {
        public void Add(User user)
        {
            using (SqlConnection connection = new SqlConnection(Constant.ConnectionString))
            {
                string sql = "INSERT INTO UserDetail(Username, Password, Admin, Name) VALUES(@Username, @Password, @Admin, @Name)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Admin", user.Admin);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(Constant.ConnectionString))
            {
                string sql = "UPDATE UserDetail SET Password = @Password, Name = @Name WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public User Read(string username)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(Constant.ConnectionString))
            {
                connection.Open();
                string sql = $"SELECT TOP 1 * FROM UserDetail WHERE Username = @Username";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Username", username);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    user.Username = Convert.ToString(dataReader["Username"]);
                    user.Name = Convert.ToString(dataReader["Name"]);
                    user.Password = Convert.ToString(dataReader["Password"]);
                    user.Admin = Convert.ToBoolean(dataReader["Admin"]);
                }

                connection.Close();
            }

            return user;
        }

        public List<User> ReadAll()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(Constant.ConnectionString))
            {
                connection.Open();
                string sql = $"SELECT * FROM UserDetail";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while(dataReader.Read())
                    {
                        User user = new User
                        {
                            Username = Convert.ToString(dataReader["Username"]),
                            Name = Convert.ToString(dataReader["Name"]),
                            Password = Convert.ToString(dataReader["Password"]),
                            Admin = Convert.ToBoolean(dataReader["Admin"])
                        };

                        users.Add(user);
                    }
                }

                connection.Close();
            }

            return users;
        }
    }
}
