using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbCon2
{
    public class User
    {
        //User Ranks 2-workers, 1-admins
        static string UserNameDB { get; set; }
        static string UserRankDB { get; set; }

        public static string GetUsetString()
        {
            string UserString = UserNameDB + " " + UserRankDB;
            return UserString;
        }


        public void Userset(string Usrename, string usrerRank)
        {
            UserNameDB = Usrename;
            UserRankDB = usrerRank;
        }

    }
}
