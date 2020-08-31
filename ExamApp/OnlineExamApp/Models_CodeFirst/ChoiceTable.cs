using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamApp.Models
{
    public class ChoiceTable
    {
        [Key]
        public int Choice_Id { get; set; }
        public int Question_Id { get; set; }
        public int ChoiceNumber { get; set; }
       
    }
}
