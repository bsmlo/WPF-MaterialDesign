using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace dbCon2
{
    class AddToDB
    {
        public void AddRecord(string name, string surname, string phone, string email)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.CnnVal()))
            {
                MySqlCommand comand = connection.CreateCommand();
                //INSERT INTO `baza_lektorow`.`lektorzy` (`Name`, `Surname`, `Phone`, `Email`) VALUES ('Marek', 'Pietrzyk', '997', 'mareczek@gmail.lol');

                comand.CommandText = $"INSERT INTO `baza_lektorow`.`lektorzy` " +
                    $"(`Name`, `Surname`, `Phone`, `Email`) " +
                    $"VALUES " +
                    $"('{ name }', '{ surname }', '{ phone }', '{ email }');";

                connection.Open();

                MySqlDataReader reader = comand.ExecuteReader();
            }
        }
    }
}
