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

    public class EFArticleRepository : EFEntityRepositoryBase<Article>, IArticleRepository
    {
        private ArticleContext _context;
        public EFArticleRepository(ArticleContext context) : base(context)
        {
            _context = context;
        }
        public List<Article> GetPaggingList(Expression<Func<Article, bool>> filter = null, int skip = 0, int take = 10)
        {
            var myResult = _context.Set<Article>().AsQueryable();
            if (filter != null)
                myResult = myResult.Where(filter);
            return myResult.Skip(skip).Take(take).ToList();
        }

    }
}
