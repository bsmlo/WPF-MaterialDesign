using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbCon2
{
    class ConnectionSettings
    {
        public static string CnnVal()
        {
            string connectingString = "server=127.0.0.1; user id =root; password =; persistsecurityinfo = True; port =3306; database = baza_lektorow; SslMode = none";
            return connectingString;
        }
    }
}
