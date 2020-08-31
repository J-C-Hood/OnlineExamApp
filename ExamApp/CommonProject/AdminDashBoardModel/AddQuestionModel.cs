using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamApp.Model.AdminDashBoardModel
{
    public class AddQuestionModel
    {
       public int TestId { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string ChoiceOne { get; set; }
        public string ChoiceTwo { get; set; }
        public string ChoiceThree { get; set; }        
    }
}
