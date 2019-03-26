using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models
{
    public class Repository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ContextClass db;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ContextClass context)
        {
            db = context;
            _dbSet = context.Set<TEntity>();
        }

        public List<Models.Domain.QuestionAnswer> FindQuestionsWithAnswers(int id)
        {
            List<Models.Domain.QuestionAnswer> a = new List<Domain.QuestionAnswer>();
            var listQuestionAnswer = db.Questions.Where(q => q.SurveyId == id).GroupJoin(db.Answers,
                                                                        q => q.Id,
                                                                        v => v.QuestionId,
                                                                        (q, v) => new
                                                                        {
                                                                            question = q.Text,
                                                                            comment = q.Comment,
                                                                            questionId = q.Id,
                                                                            surveyId = q.SurveyId,
                                                                            answers = v.Select(ans => ans.Text)
                                                                        });
            foreach (var item in listQuestionAnswer)
            {
                a.Add(new Models.Domain.QuestionAnswer(item.question, item.comment, item.questionId, item.surveyId, item.answers));
            }
            return a;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            db.SaveChanges();
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            db.SaveChanges();
        }

        public void Update(TEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
