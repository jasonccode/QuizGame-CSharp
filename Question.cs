using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public List<Option> Options { get; set; }
    }
}