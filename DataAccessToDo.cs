using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace dbCon2
{
    class DataAccessToDo
    {
        public List<ToDoRecord> GetToDosMonth(string year, string month)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText =
                        $"Select* from `todo` WHERE UserID = '{LoginWindow.LoggedIn.GetID()}' AND  MONTH(Date) " +
                        $"= {month} AND YEAR(Date) " +
                        $"= {year} ORDER BY `todo`.`Is_Done` DESC, `todo`.`Date` DESC ;";


                    List<ToDoRecord> output = new List<ToDoRecord>();

                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ToDoRecord toDo = new ToDoRecord
                        {
                            Date = reader["Date"].ToString().Substring(0, reader["Date"].ToString().IndexOf(" ")),
                            Title = reader["Title"].ToString(),
                            Coworkers = reader["Co-Worker"].ToString(),
                            Description = reader["Description"].ToString(),
                            UserID = reader["UserID"].ToString(),
                            ID = reader["ID"].ToString(),
                            IsDone = reader["Is_Done"].ToString()
                        };

                        output.Add(toDo);
                    }

                    return output;
                }
            }
            catch
            {
                MessageBox.Show("Cant connect to DB");
                return null;
            }

        }

        public void MarkAsDone(string IDtoChange)
        {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText =
                        $"Select* from `todo` WHERE ID = '{ IDtoChange }';";

                    ToDoRecord output = new ToDoRecord();

                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        output.IsDone = reader["Is_Done"].ToString();
                    };
                    connection.Close();


                    if (output.IsDone == "inProgress")
                    {
                        command.CommandText = 
                            $"UPDATE `baza_lektorow`.`todo` SET `Is_Done`='Done' WHERE  `ID`={ IDtoChange };";

                    }
                    else
                    {
                        command.CommandText =
                           $"UPDATE `baza_lektorow`.`todo` SET `Is_Done`='inProgress' WHERE  `ID`={ IDtoChange };";
                    }
                    connection.Open();

                    MySqlDataReader changeRecord = command.ExecuteReader();
                    
                }
                
            }
            catch
            {
                
            }

        }
    }
}
