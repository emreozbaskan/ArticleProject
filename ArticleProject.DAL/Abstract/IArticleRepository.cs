using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.DAL.Abstract
{
    using Core.DAL;
    using Entities.Concrete;

    public interface IArticleRepository : IEntityRepository<Article>
    {

    }
}
