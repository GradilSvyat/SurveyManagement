using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models
{
    public class Survey
    {
        private int Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public DateTime Date { get; set; }

    }
}
