using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace dbCon2
{
    class AddnewToDoDB
    {
        public void AddToDoDB(string date, string title, string coworker, string description, string userid)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "INSERT INTO `baza_lektorow`.`todo` " +
                                "(`Date`, `Title`, `Co-Worker`, `Description`, `UserID`, `Is_Done`) " +
                                $"VALUES ('{date}', '{title}', '{coworker}', '{description}', '{userid}', 'inProgress');";

                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Can't connect to DB");
            }
        }
    }
}
