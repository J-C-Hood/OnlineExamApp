using System;
using System.Collections.Generic;

namespace OnlineExamApp.Model
{
    public partial class Assignedtesttable
    {
        public string EmailId { get; set; }
        public int? TestId { get; set; }
        public int? CorrectAnswers { get; set; }
        public int? WrongAnswers { get; set; }
        public float? Percentage { get; set; }
        public int AssignedTestId { get; set; }

        public virtual Customeraccount Email { get; set; }
    }
}
