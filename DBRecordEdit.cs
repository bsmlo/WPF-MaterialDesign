using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;


namespace dbCon2
{
    class DBRecordEdit
    {
        public void EditRecord(string name, string surname, string phone, string email, string id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = "UPDATE `lektorzy` SET " +
                        $"`Name` = '{name}', `Surname` = '{surname}', `Phone` = '{phone}', `Email` = '{email}'" +
                        $"WHERE `lektorzy`.`ID` = '{id}';";

                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    connection.Close();

                    MessageBox.Show("Record edited!");
                }
            }
            catch
            {
                MessageBox.Show("Can't connect to DB");
            }
        }
    }
}
