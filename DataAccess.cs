﻿using System;
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

        public List<Person> GetPeople(string name, string surname, string phone, string email, bool seachType)
        {

            using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.CnnVal()))
            {
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = $"SELECT * FROM lektorzy WHERE ";

                //true = OR searching
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

                if(name != "Name")
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
                

                List<Person> output = new List<Person>();

                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    ExecuteStatus = ex.Message.ToString();
                }

                if (connection.State.ToString() == "Open" && comandReady)
                {
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        //MessageBox.Show(reader["Surname"].ToString());

                        Person person = new Person
                        {
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"].ToString()
                        };

                        output.Add(person);
                       
                        //MessageBox.Show(person.Phone.ToString());
                    }

                    if(output.Count()>0)
                    {
                        ExecuteStatus = "Execute Compled!";
                        Color = new SolidColorBrush(Colors.Green);
                    }
                    else
                    {
                        ExecuteStatus = "No Records Found";
                        Color = new SolidColorBrush(Colors.Yellow);
                    }

                    comandReady = false;
                    return output;
                }

                else
                {
                    if(comandReady == false)
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
    }
}
