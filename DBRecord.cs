using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbCon2
{
    public class DBRecord
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{ ID } { Name } { Surname } { Phone } ({ Email })";
            }
        }
    }
}
