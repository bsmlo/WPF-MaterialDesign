using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace dbCon2
{
    class AddCoworkerDB
    {
        public void AddRecord(string name, string surname, string phone, string email)
        {
            try
            {

                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    MySqlCommand comand = connection.CreateCommand();
                    //INSERT INTO `baza_lektorow`.`lektorzy` (`Name`, `Surname`, `Phone`, `Email`) VALUES ('Marek', 'Pietrzyk', '997', 'mareczek@gmail.lol');

                    comand.CommandText = $"INSERT INTO `baza_lektorow`.`lektorzy` " +
                        $"(`Name`, `Surname`, `Phone`, `Email`) " +
                        $"VALUES " +
                        $"('{ name }', '{ surname }', '{ phone }', '{ email }');";

                    connection.Open();

                    MySqlDataReader reader = comand.ExecuteReader();

                    //connection.Close();

                }
                
            }
            catch
            {
                MessageBox.Show("Can't connect to Database");
            }
        }
    }
}
