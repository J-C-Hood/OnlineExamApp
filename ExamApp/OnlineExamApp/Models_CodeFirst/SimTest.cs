using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExamApp.Models
{
    public class SimTest
    {
        [Key]
        public int SimTest_Number { get; set; }
        public string Test_Name { get; set; }
        public int Duration { get; set; }
        public int Percentage { get; set; }
        public int No_Of_Questions { get; set; }
        [ForeignKey("CustomerAccounts")]
        public int Cust_Id;
    }
}
