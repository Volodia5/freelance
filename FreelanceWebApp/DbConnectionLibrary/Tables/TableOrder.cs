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
    public class TableOrder
    {
        public List<Order> GetOrdersByCategory(int category_id)
        {
            List<Order> orders = new List<Order>();

            using (MySqlConnection connection = DbConnector.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = $@"SELECT * FROM `users_order` AS uo
                    JOIN `order` AS o ON uo.order_id = o.id
                    WHERE uo.`category_id`= {category_id}";

                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            orders.Add(new Order(
                                reader.GetInt32("id"),
                                reader.GetString("title"),
                                reader.GetString("status"),
                                reader.GetInt32("price"),
                                reader.GetString("place"),
                                reader.GetString("description"),
                                reader.GetString("deadline"),
                                reader.GetInt32("employerId"),
                                reader.GetInt32("specialistId")
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

            return orders;
        }

        public void AcceptOrder(int employerId, int orderId)
        {
            using (MySqlConnection connection = DbConnector.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"UPDATE `order` SET `employerId`={employerId}, `status`='Активный' WHERE `id`={orderId}";
                    command.ExecuteNonQuery();
                }

                connection.Clone();
            }
        }
    }
}
