using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.DAL.Abstract
{
    using Entities.Concrete;
    using Core.DAL;

    public interface ICategoryRepository : IEntityRepository<Category>
    {

    }
}
