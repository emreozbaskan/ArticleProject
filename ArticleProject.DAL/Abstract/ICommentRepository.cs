using ArticleProject.Core.DAL;
using ArticleProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.DAL.Abstract
{
    public interface ICommentRepository: IEntityRepository<Comment>
    {

    }
}
