using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamApp.Model.AdminDashBoardModel
{
    public class QuestionModel
    {
        public string TaskName;
        public int TaskID;
        public int QuestionNumber;
        public string QuestionDescription;
        public List<string> Options = new List<string>();
        public string ChoosenAnswer;
      
    }
}
