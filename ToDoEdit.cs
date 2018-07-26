using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace dbCon2
{
    class ToDoEdit
    {
        public void EditRecord(string date, string title, string coworker, string description, string taskID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE `todo` SET " +
                        $"`Date` = '{date}', `Title` = '{title}', `Co-Worker` = '{coworker}', `Description` = '{description}'" +
                        $"WHERE `todo`.`ID` = '{taskID}';";

                    //     "INSERT INTO `baza_lektorow`.`todo` " +
                    //             "(`Date`, `Title`, `Co-Worker`, `Description`, `UserID`, `Is_Done`) " +
                    //             $"VALUES ('{date}', '{title}', '{coworker}', '{description}', '{userid}', 'inProgress');";

                    //  UPDATE `todo` SET `Description` = 'dbsvgdftvhthbtvyhjftyv' WHERE `todo`.`ID` = 40;

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
