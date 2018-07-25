using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace dbCon2
{
    class ToDoRemove
    {
        public ToDoRemove(List<int> itemsToRemove)
        {

            using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
            {
                MySqlCommand comand = connection.CreateCommand();

                foreach (int IDtoRemove in itemsToRemove)
                {
                    connection.Open();
                    comand.CommandText = $"DELETE FROM `todo` WHERE ID = { IDtoRemove };";
                    comand.ExecuteReader();
                    connection.Close();
                }
            }
            MessageBox.Show("Data has been removed successfully");
        }
    }
}
