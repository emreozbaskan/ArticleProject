using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;


namespace ArticleProject.Core.DAL
{
    using Entities.Abstract;

    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        T Update(T entity);
        bool Delete(T entity);
    }
}
