using System;
using System.Collections.Generic;

namespace OnlineExamApp.Model
{
    public partial class Questions
    {
        public Questions()
        {
            Choicetable = new HashSet<Choicetable>();
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public int? TestId { get; set; }

        public virtual Simtest Test { get; set; }
        public virtual ICollection<Choicetable> Choicetable { get; set; }
    }
}
