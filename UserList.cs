using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace dbCon2
{
    class UserList
    {
        public List<User> GetAllUsers()
        {
            try
            {
                ConnectionSettings connectionSettings = new ConnectionSettings();
                connectionSettings.ConnectionSet();


                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    List<User> Users = new List<User>();

                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = $"SELECT * FROM users;";

                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        User user = new User
                        {
                            DefaultUser = false,
                            UserID = reader["User_ID"].ToString(),
                            UserNameDB = reader["User_Name"].ToString(),
                            UserRankDB = reader["User_Rank"].ToString()
                        };
                        //user.Userset(reader["User_Name"].ToString(), reader["User_Rank"].ToString(), reader["User_ID"].ToString(), false);
                        Users.Add(user);
                    };

                    connection.Close();

                    return Users;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
