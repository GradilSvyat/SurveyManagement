using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models
{
    public class ContextClass : DbContext
    {
        public DbSet<Domain.Survey> Surveys { get; set; }
        public DbSet<Domain.Question> Questions { get; set; }
        public DbSet<Domain.Answer> Answers { get; set; }

        public ContextClass(DbContextOptions<ContextClass> options)
           : base(options)
        {
        }
    }
}
