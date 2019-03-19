using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models.Domain
{
    public class Survey
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public DateTime Date { get; set; }

        public Survey(int id, string name, string creator, DateTime date)
        {
            this.Id = id;
            this.Name = name;
            this.Creator = creator;
            this.Date = date;
        }
    }
}
