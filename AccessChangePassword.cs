using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace dbCon2
{
    class AccessChangePassword
    {
        public AccessChangePassword(string userId, string newPassword)
        {
            try
            {
                ConnectionSettings connectionSettings = new ConnectionSettings();
                connectionSettings.ConnectionSet();

                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = $"UPDATE `baza_lektorow`.`users` SET `User_Password`='{newPassword}' WHERE  `User_ID`={userId};";

                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    connection.Close();

                    MessageBox.Show("Password Changed!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Password change faild! Check connection.");
            }
        }

    }
}
