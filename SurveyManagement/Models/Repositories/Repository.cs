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

        public IQueryable FindQuestionsWithAnswers(int id)
        {
            return db.Questions.Where(q => q.SurveyId == id).GroupJoin(db.Answers,
                                                                        q => q.Id,
                                                                        v => v.QuestionId,
                                                                        (q, v) => new
                                                                        {
                                                                            x = q.Text,
                                                                            z = q.Comment,
                                                                            y = v.Select(ans => ans.Text)
                                                                        });
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

        //public virtual IReadOnlyCollection<TEntity> FindAllById<TEntity>(int id, Func<TEntity> func)
        //{
        //    return db.Set<TEntity>().AsNoTracking().ToList<TEntity>();//.Select<int, TEntity>(func);
        //}

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
