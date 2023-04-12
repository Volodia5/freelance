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
    public class TableCategory
    {
        public List<Category> GetAllCategories()
        {
            List<Category> categories= new List<Category>();

            using (MySqlConnection connection = DbConnector.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = $@"SELECT * FROM `category`";

                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            categories.Add(new Category(
                                reader.GetInt32("id"),
                                reader.GetString("title")
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

            return categories;
        }
    }
}
