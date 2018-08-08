using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbCon2
{
    public class ContractItem
    {
        public string Id {get; set;}
        public string Status {get; set;}
        public string Worker {get; set;}
        public string Date {get; set;}
        public string Client {get; set;}
        public string Contact {get; set;}
        public string InvoiceStatus {get; set;}
        public string ExpiryDate {get; set;}
        public string Other {get; set;}

        public void SetItem (string id, string status, string worker, string date, string client, string contact, string invStat, string expiDate, string other)
        {
            Id = id;
            Status = status;
            Worker = worker;
            Date = date;
            Client = client;
            Contact = contact;
            InvoiceStatus = invStat;
            ExpiryDate = expiDate;
            Other = other;
        }
    }
}
