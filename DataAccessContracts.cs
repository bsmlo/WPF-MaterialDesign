﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace dbCon2
{
    class DataAccessContracts
    {
        //load list of contracts from database
        public List<ContractItem> GetContracts()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = $"SELECT * FROM `contracts`;";

                    List<ContractItem> output = new List<ContractItem>();

                    try
                    {
                        connection.Open();
                    }
                    catch
                    {
                        MessageBox.Show("Can't Connect To DB!");
                    }

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ContractItem contract = new ContractItem
                        {
                            Id = reader["id"].ToString(),
                            Status = reader["status"].ToString(),
                            Worker = reader["worker"].ToString(),
                            Date = reader["date"].ToString().Substring(0, reader["date"].ToString().IndexOf(" ")),
                            Contact = reader["contact"].ToString(),
                            Client = reader["client"].ToString(),
                            InvoiceStatus = reader["invoice_status"].ToString(),
                            ExpiryDate = reader["expiry_date"].ToString().Substring(0, reader["expiry_date"].ToString().IndexOf(" ")),
                            Other = reader["other"].ToString()
                        };
                       
                        output.Add(contract);
                    }

                    return output;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        
        public void AddNewContract(string id, string status, string worker, string date, string client, string contact, string invStat, string expiDate, string other)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionSettings.ConectionVal()))
                {
                    MySqlCommand command = connection.CreateCommand();


                    //update or insert to db
                    if(id != "" && id != null)
                    {
                        command.CommandText = $"UPDATE `contracts` SET " +
                            $"`status` = '{status}'," +
                            $"`worker` = '{worker}'," +
                            $"`date` = '{date}', " +
                            $"`client` = '{client}'," +
                            $"`contact` = '{contact}'," +
                            $"`invoice_status` = '{invStat}'," +
                            $"`expiry_date` = '{expiDate}'," + 
                            $"`other` = '{other}'" + 
                            $"WHERE `contracts`.`id` = '{id}';";

                        try
                        {
                            connection.Open();
                            //MessageBox.Show("try to execute");
                            MySqlDataReader reader = command.ExecuteReader();
                        }
                        catch
                        {
                            MessageBox.Show("Can't Connect To DB!");
                        }
                    }
                    else if (id == "" && id != null)
                    {
                        command.CommandText = $"INSERT INTO `contracts` " +
                            $"(`status`, `worker`, `date`, `client`, `contact`, `invoice_status`, `expiry_date`, `other`)" +
                            $"VALUES" +
                            $"('{status}', '{worker}', '{date}', '{client}', '{contact}', '{invStat}', '{expiDate}', '{other}');";

                        try
                        {
                            connection.Open();
                            //MessageBox.Show("try to execute");
                            MySqlDataReader reader = command.ExecuteReader();
                        }
                        catch
                        {
                            MessageBox.Show("Can't Connect To DB!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Edit error");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't Connect To DB!");

            }
        }
    }
}
