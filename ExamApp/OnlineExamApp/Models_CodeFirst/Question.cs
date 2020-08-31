using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamApp.Models
{
    public class Question
    {
        [Key]
        public int Question_Id { get; set; }
        public string Questions { get; set; }
        public string CorrectAnswer { get; set; }
        public int MyProperty { get; set; }
        public int Test_Id { get; set; }
    }
}
