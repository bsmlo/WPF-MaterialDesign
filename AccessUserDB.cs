using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;

namespace dbCon2
{
    class AccessUserDB
    {
        public User TryToFindUser(string userName, string password)
        {
            try
            {
                ConnectionSettings connectionSettings = new ConnectionSettings();
                connectionSettings.ConnectionSet();


                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    User user = new User();
                    string passwordFromDB = "";

                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = $"SELECT * FROM users WHERE User_Name='{ userName }' AND User_Password='{ password }';";
                    
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        user.Userset(reader["User_Name"].ToString(), reader["User_Rank"].ToString(), reader["User_ID"].ToString(), false);
                        passwordFromDB = reader["User_Password"].ToString();
                    };

                    connection.Close();

                    if(user.UserNameDB == userName && passwordFromDB == password)
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                    
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Can't connect! Login in as default admin and configurate connection.");
                return null;
            }
        }
    }
}
