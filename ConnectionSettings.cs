using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbCon2.Properties;

namespace dbCon2
{
    class ConnectionSettings
    {
        static string Server { get; set; }
        static string User_id { get; set; }
        static string Password { get; set; }
        static string Persistsecurityinfo { get; set; }
        static string Port { get; set; }
        static string Database { get; set; }
        static string SslMode { get; set; }

        //Connection String Co-Workers
        public static string ConectionVal()
        {
            string connectingString = 
                $"server= {Server}; user id = {User_id}; password = {Password}; " +
                $"persistsecurityinfo = {Persistsecurityinfo}; port ={Port}; " +
                $"database ={Database}; SslMode ={SslMode}";
            return connectingString;
        }

        public void ConnectionSet()
        {
            Server = Settings.Default.Server;
            User_id = Settings.Default.User_id;// "root";
            Password = Settings.Default.Password; // "" ;
            Persistsecurityinfo = Settings.Default.Persistsecurityinfo; // "True";
            Port = Settings.Default.Port; // "3306";
            Database = Settings.Default.Database; // "baza_lektorow";
            SslMode = Settings.Default.SslMode; // "none";
        }
    }
}
