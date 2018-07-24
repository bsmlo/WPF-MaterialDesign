using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows;


//Deleting From Database items with IDs from The list
namespace dbCon2
{
    public class DeleteItems
    {
        public DeleteItems(List<int> itemsToRemove)
        {

            using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
            {
                MySqlCommand comand = connection.CreateCommand();

                foreach (int IDtoRemove in itemsToRemove)
                {
                    connection.Open();
                    comand.CommandText = $"DELETE FROM lektorzy WHERE ID = { IDtoRemove };";
                    comand.ExecuteReader();
                    connection.Close();
                }
            }
        }
    }

}