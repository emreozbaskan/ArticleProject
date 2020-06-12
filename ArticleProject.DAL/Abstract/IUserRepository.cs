using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.DAL.Abstract
{
    using Core.DAL;
    using Core.Entities.Concrete;
    public interface IUserRepository : IEntityRepository<User>
    {

    }
}
