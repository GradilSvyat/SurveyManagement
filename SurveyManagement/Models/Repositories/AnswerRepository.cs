using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models.Repositories
{
    public class AnswerRepository : Repository<Domain.Answer>
    {
        public AnswerRepository(ContextClass context)
            : base(context)
        {
        }

        public IReadOnlyCollection<Domain.Answer> FindAllById(int id)
        {
            return _dbSet.Where(x => x.QuestionId == id).ToList<Domain.Answer>();
        }
    }
}
