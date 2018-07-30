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
        public string Name { get; set; }
        public string Rank { get; set; }
        public string ID { get; set; }

        public string TryToFindUser(string userName, string password)
        {
          
            try
            {
                ConnectionSettings connectionSettings = new ConnectionSettings();
                connectionSettings.ConnectionSet();

                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = $"SELECT * FROM users WHERE User_Name='{ userName }' AND User_Password='{ password }';";


                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        Name = reader["User_Name"].ToString();
                        Rank = reader["User_Rank"].ToString();
                        ID = reader["User_ID"].ToString();
                    };

                    connection.Close();

                    if(Rank == "1" || Rank == "2")
                    {
                        return "OK";
                    }
                    else
                    {
                        return "Wrong username or password!";
                    }
                    
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Can't connect! Login in as default admin and configurate connection.");
                return "Connection Problem";
            }
        }
    }
}
