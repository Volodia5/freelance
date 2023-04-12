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
    public class TableUsersOrder
    {
        public string AddOrder(int employerId, int category_id, Order order)
        {
            using (MySqlConnection connection = DbConnector.GetConnection())
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = $"INSERT INTO `order`(`title`,`status`,`price`,`place`,`deadline`,`description`, `employerId`, `specialistId`) VALUES ('{order.Title}', '{order.Status}', {order.Price}, '{order.Place}', '{order.DeadLine}', '{order.Description}', 0, 0);";
                        command.ExecuteNonQuery();

                        command.CommandText = "SELECT last_insert_id();";
                        int orderId = Convert.ToInt32(command.ExecuteScalar());

                        command.CommandText = $"INSERT INTO `users_order` (`employer_id`,`order_id`, `category_id`) VALUES ({employerId}, {orderId}, {category_id});";
                        command.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }

                connection.Close();
            }
            return "Order was created";
        }

        public void UpdateOrderWithEmployerId(int specialistId, int orderId)
        {
            using (MySqlConnection connection = DbConnector.GetConnection())
            {
                connection.Open();


                using (MySqlCommand command = connection.CreateCommand())
                {

                    try
                    {
                        command.CommandText = $"UPDATE `users_order` SET `specialist_id`={specialistId} WHERE `order_id` = {orderId}";
                        command.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }

                connection.Close();
            }
        }

        public List<Order> GetOrdersByEmployerId(int employerId)
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
                    WHERE uo.`employer_id`= {employerId}";

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

        public List<Order> GetOrdersBySpecialistId(int specialistId)
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
                    WHERE uo.`specialist_id`= {specialistId}";

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
    }
}
