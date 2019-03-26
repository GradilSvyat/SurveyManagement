using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models.Domain
{
    public class QuestionAnswer
    {
        public Question Questions;
        public List<Answer> Answers;

        public QuestionAnswer (string question, string comment, int questionId, int surveyId, IEnumerable<string> answers)
        {
            Answers = new List<Answer>();
            Questions = new Question(question, comment, questionId, surveyId);
            foreach(string answer in answers)
            {
                Answers.Add(new Answer(questionId, answer));
            }
        }
    }
}
