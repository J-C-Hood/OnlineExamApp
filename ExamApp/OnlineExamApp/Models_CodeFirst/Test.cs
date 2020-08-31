using Renci.SshNet.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamApp.Models
{
    public class Test
    {
       [Key]
        public int Test_Id { get; set; }
        public int Cust_ID { get; set; }
        public int No_Of_CorrectAns { get; set; }
        public int No_Of_WrongAns { get; set; }
        public int Percentage { get; set; }
    }
}
