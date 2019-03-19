using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models
{
    public class QuestionRepository : Repository<Domain.Question>
    {
        public QuestionRepository(ContextClass context)
            :base(context)
        {
        }

        public IReadOnlyCollection<Domain.Question> FindAllById(int id)
        {
            return _dbSet.Where(x => x.SurveyId == id).ToList<Domain.Question>();
        }
    }
}
