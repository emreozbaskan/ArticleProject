using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.DAL.Abstract
{
    using Core.DAL;
    using Entities.Concrete;
    using System.Linq.Expressions;

    public interface IArticleRepository : IEntityRepository<Article>
    {
        List<Article> GetPaggingList(Expression<Func<Article, bool>> filter = null, int skip = 0, int take = 10);
    }
}
