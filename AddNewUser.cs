using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;


namespace dbCon2
{
    public class AddNewUser
    {
        public AddNewUser(string userName, string password, string userRank)
        {
            try
            {
                ConnectionSettings connectionSettings = new ConnectionSettings();
                connectionSettings.ConnectionSet();
                
                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = $"INSERT INTO users (`User_Name`, `User_Password`, `User_Rank`) VALUES ('{ userName }', '{ password }', '{ userRank }');";

                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    
                    connection.Close();

                    MessageBox.Show("User added!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Can't add new user! Check connection.");
            }
        }
    }
}
