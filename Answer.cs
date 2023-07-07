using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Answer
    {
        public int QuestionId { get; set; }
        public Option SelectedOption { get; set; }
    }
}