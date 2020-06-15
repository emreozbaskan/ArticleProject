using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace ArticleProject.DAL.Concrete.EntityFramework
{
    using Abstract;
    using Core.DAL.EntityFramework;
    using Context;
    using Entities.Concrete;


    public class EFArticleRepository : EFEntityRepositoryBase<Article, ArticleContext>, IArticleRepository
    {
        public List<Article> GetPaggingList(Expression<Func<Article, bool>> filter = null, int skip = 0, int take = 10)
        {
            using (ArticleContext DB = new ArticleContext())
            {
                var myResult = DB.Set<Article>().AsQueryable();
                if (filter != null)
                    myResult = myResult.Where(filter);
                return myResult.Skip(skip).Take(take).ToList();
            }
        }

    }
}
