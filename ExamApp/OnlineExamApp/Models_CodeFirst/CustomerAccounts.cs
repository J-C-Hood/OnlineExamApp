using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamApp.Models
{
    public class CustomerAccounts
    {
        // Cust Id, First Name, Last Name, Email Id, Password(encrypted), Phone Number
        [Key]
        public int Cust_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string EMail_Id { get; set; }
        public string Password { get; set; }
        public int Number { get; set; }
    }
}
