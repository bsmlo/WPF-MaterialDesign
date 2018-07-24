using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Media;

namespace dbCon2
{
    public class DataAccess
    {
        public string ExecuteStatus { get; set; }
        public SolidColorBrush Color { get; set; }

        public List<DBRecord> GetPeople(string name, string surname, string phone, string email, bool seachType)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = $"SELECT * FROM lektorzy WHERE ";

                    //true for OR searching, false for AND
                    string askType;
                    bool comandReady = false;

                    if (seachType == true)
                    {
                        askType = " OR ";
                    }
                    else
                    {
                        askType = " AND ";
                    }

                    if (name != "Name")
                    {
                        command.CommandText += $"Name LIKE '%{name}%'";
                        if (surname != "Surname" || phone != "Phone" || email != "Email")
                        {
                            command.CommandText += askType;
                        }
                        comandReady = true;
                    }

                    if (surname != "Surname")
                    {
                        command.CommandText += $"Surname LIKE '%{surname}%'";
                        if (phone != "Phone" || email != "Email")
                        {
                            command.CommandText += askType;
                        }
                        comandReady = true;
                    }

                    if (phone != "Phone")
                    {
                        command.CommandText += $"Phone LIKE '%{phone}%'";
                        if (email != "Email")
                        {
                            command.CommandText += askType;
                        }
                        comandReady = true;
                    }

                    if (email != "Email")
                    {
                        command.CommandText += $"Email LIKE '%{email}%'";
                        comandReady = true;
                    }


                    List<DBRecord> output = new List<DBRecord>();

                    try
                    {
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        ExecuteStatus = ex.Message.ToString();
                    }

                    if (connection.State.ToString() == "Open" && comandReady)
                    {
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            DBRecord person = new DBRecord
                            {
                                ID = reader["ID"].ToString(),
                                Name = reader["Name"].ToString(),
                                Surname = reader["Surname"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Email = reader["Email"].ToString()
                            };

                            output.Add(person);
                        }

                        if (output.Count() > 0)
                        {
                            ExecuteStatus = "Execute Compled!";
                            Color = new SolidColorBrush(Colors.Green);
                        }
                        else
                        {
                            ExecuteStatus = "No Records Found";
                            Color = new SolidColorBrush(Colors.Orange);
                        }

                        comandReady = false;
                        return output;
                    }

                    else
                    {
                        if (comandReady == false)
                        {
                            ExecuteStatus += "\r\nType Something";
                        }
                        else
                        {
                            ExecuteStatus += "\r\nDB Connection Problem";
                        }

                        Color = new SolidColorBrush(Colors.Red);

                        return null;
                    }

                }
            }
            catch(Exception ex)
            {
                ExecuteStatus += "\r\nDB Connection Problem";
                Color = new SolidColorBrush(Colors.Red);
                return null;
            }
        }
    }
}
