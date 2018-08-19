using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace dbCon2
{
    class DeleteUser
    {
        public DeleteUser(string IDtoRemove)
        {

            using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
            {
                MySqlCommand comand = connection.CreateCommand();

                //Delete User
                connection.Open();
                comand.CommandText = $"DELETE FROM users WHERE User_ID = { IDtoRemove };";
                comand.ExecuteReader();
                connection.Close();

                //Delete user's todos
                connection.Open();
                comand.CommandText = $"DELETE FROM todo WHERE UserID = { IDtoRemove };";
                comand.ExecuteReader();
                connection.Close();

                MessageBox.Show("User has been removed!");
            }
        }
    }
}
