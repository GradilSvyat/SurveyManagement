using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models.Domain
{
    public class Answer
    {
        public int Id { get; private set; }
        public int QuestionId { get; private set; }
        public string Text { get; set; }

        public Answer(int id, string text, int questionId)
        {
            this.Id = id;
            this.Text = text;
            this.QuestionId = questionId;
        }
    }
}
