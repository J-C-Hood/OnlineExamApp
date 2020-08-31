using System;
using System.Collections.Generic;

namespace OnlineExamApp.Model
{
    public partial class Choicetable
    {
        public int ChoiceId { get; set; }
        public int? QuestionId { get; set; }
        public string ChoiceOne { get; set; }
        public string ChoiceTwo { get; set; }
        public string ChoiceThree { get; set; }
        public string ChoiceFour { get; set; }

        public virtual Questions Question { get; set; }
    }
}
