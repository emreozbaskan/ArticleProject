using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.DAL.Concrete.EntityFramework
{
    using Abstract;
    using Core.DAL.EntityFramework;
    using Context;
    using ArticleProject.Entities.Concrete;

    public class EFCommentRepository: EFEntityRepositoryBase<Comment, ArticleContext>, ICommentRepository
    {

    }
}
