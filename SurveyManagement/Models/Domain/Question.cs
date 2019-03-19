using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models.Domain
{
    public class Question
    {
        public int Id { get; private set; }
        public string Text { get; set; }
        public string Comment { get; set; }
        public int SurveyId { get; private set; }

        public Question (int id, string text, string comment, int surveyId)
        {
            this.Id = id;
            this.Text = text;
            this.Comment = comment;
            this.SurveyId = surveyId;
        }
    }
}
