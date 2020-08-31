using System;
using System.Collections.Generic;

namespace OnlineExamApp.Model
{
    public partial class Simtest
    {
        public Simtest()
        {
            Questions = new HashSet<Questions>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public float? Duration { get; set; }
        public float? Percentage { get; set; }
        public int? NoOfQuestions { get; set; }
        public string EmailId { get; set; }

        public virtual Customeraccount Email { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
