using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace dbCon2
{
    public class User
    {
        //User Ranks 2-workers, 1-admins
        public string UserNameDB { get; set; }
        public string UserRankDB { get; set; }
        public string UserID { get; set; }
        public bool DefaultUser { get; set; }

        public string GetUsetString()
        {
            string rankTxt = "";

            if (UserRankDB == "1")
            {
                rankTxt = "Admin";
            }
            else if (UserRankDB == "2")
            {
                rankTxt = "Worker";
            }

            string UserString = UserNameDB + "\t" + rankTxt;
            return UserString;
        }

        public string FullInfo
        {
            get
            {
                return $"{UserID} \t {GetUsetString()}";
            }
            
        }

        //
        public string GetUserNameStat()
        {
            return UserNameDB;
        }
        
        //get name of user
        public string GetUserName
        {
            get
            {
                return UserNameDB;
            }
        }

        //Visable or not content on acount page
        public string GetRank()
        {
            string rankTxt = "";

            if (UserRankDB == "1")
            {
                rankTxt = "visable";
            }
            else
            {
                rankTxt = "";
            }

            return rankTxt;
        }


        public string GetID
        {
            get
            {
                return UserID;
            }
        }


        public bool IsUserDefault()
        {
            if (DefaultUser == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string GetRankNumr()
        {
            return UserRankDB;
        }

        public void Userset(string Usrename, string usrerRank, string userID, bool isDefault)
        {
            UserNameDB = Usrename;
            UserRankDB = usrerRank;
            UserID = userID;
            DefaultUser = isDefault;
        }
    }
}
