using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models
{
    public class Question
    {
        private int Id { get; set; }
        private int Survey_id { get; set; }
        public string Text { get; set; }
        public string Coment { get; set; }
    }
}
