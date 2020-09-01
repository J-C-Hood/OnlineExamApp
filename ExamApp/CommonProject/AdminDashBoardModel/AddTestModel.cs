using OnlineExamApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamApp.Model.AdminDashBoardModel
{
    public class AddTestModel
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public float? Duration { get; set; }
        public float? Percentage { get; set; }
        public int? NoOfQuestions { get; set; }
        public string EmailId { get; set; }
    }
}
