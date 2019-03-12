using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models
{
    public class Variants_answer
    {
        private int ID { get; set; }
        private int Question_id { get; set; }
        public string Text { get; set; }
    }
}
