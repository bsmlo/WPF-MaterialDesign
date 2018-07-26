using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbCon2
{
    class ToDoRecord
    {
        public string Date { get; set; }
        public string Title { get; set; }
        public string Coworkers { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }
        public string ID { get; set; }
        public string IsDone { get; set; }

        public string FullInfoToDo
        {
            get
            {
                return $"{ Date }, { Title }, { Coworkers }, { IsDone }";
            }
        }

        public string GetDate
        {
            get
            {
                return String.Format("{0}-{1}-{2}", Convert.ToDateTime(Date).Year, Convert.ToDateTime(Date).Month,
                    Convert.ToDateTime(Date).Day);
            }
        }

        public string GetDescription
        {
            get
            {
                return $"{ Description }";
            }
        }
    }
}
