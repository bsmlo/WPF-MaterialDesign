using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace dbCon2
{
    class DeleteContract
    {
        public void RemoveContract(string id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = $"DELETE FROM `baza_lektorow`.`contracts` WHERE  `id`='{id}';";

                    try
                    {
                        connection.Open();
                        MySqlDataReader reader = command.ExecuteReader();
                    }
                    catch
                    {
                        MessageBox.Show("Can't Connect To DB!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't Connect To DB!");

            }
        }
    }
}
