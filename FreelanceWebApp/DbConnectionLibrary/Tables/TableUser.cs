using DbConnectionLibrary.Tools;
using EntityLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnectionLibrary.Tables
{
    public class TableUser
    {
        public User GetUserByLoginAndPassword(string login, string password)
        {
            User user = null;

            using (MySqlConnection connection = DbConnector.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM `user` WHERE `login`='{login}' AND `password`='{password}'";

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();

                        user = new User(
                            reader.GetInt32("id"),
                            reader.GetString("login"),
                            reader.GetString("password"),
                            reader.GetString("name"),
                            reader.GetString("email"),
                            reader.GetString("phone"),
                            reader.GetString("bio"),
                            reader.GetInt32("avg_rating"),
                            reader.GetInt32("classification_id"),
                            reader.GetInt32("role_id"),
                            reader.GetInt32("category_id")
                        );
                    }

                    reader.Close();
                }

                connection.Close();
            }

            return user;
        }

        public List<User> GetAllSpecialistsByCategory(int categoryId)
        {

            List<User> specialists = new List<User>();

            using (MySqlConnection connection = DbConnector.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = $@"SELECT * FROM `user` WHERE `category_id`= {categoryId}";

                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            specialists.Add(new User(
                            reader.GetInt32("id"),
                            reader.GetString("login"),
                            reader.GetString("password"),
                            reader.GetString("name"),
                            reader.GetString("email"),
                            reader.GetString("phone"),
                            reader.GetString("bio"),
                            reader.GetInt32("avg_rating"),
                            reader.GetInt32("classification_id"),
                            reader.GetInt32("role_id"),
                            reader.GetInt32("category_id")
                                ));
                        }

                        reader.Close();

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }

                connection.Close();
            }

            return specialists;
        }

        public string AddUser(User user)
        {
            using (MySqlConnection connection = DbConnector.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO `user` (`login`,`password`,`name`,`email`,`bio`, `role_id`, `classification_id`, `phone`) VALUES ('{user.Login}', '{user.Password}', '{user.Name}', '{user.Email}', '{user.Bio}', {user.RoleId}, {user.ClassificationId}, '{user.Phone}');";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            return "User was created";
        }
    }
}
