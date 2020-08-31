using System;
using System.Collections.Generic;

namespace OnlineExamApp.Model.AdminDashBoardModel
{
    public class UpdateTestModel
    {
        public int TestId;
        public string TestName;
        public float TestDuration;
        public int CustomerId;
        public float Percentage;
        public List<Tuple<int, string>> QuestionLists = new List<Tuple<int, string>>();
        public List<Tuple<int, string>> AssignedStudentIds = new List<Tuple<int, string>>();
    }
}
