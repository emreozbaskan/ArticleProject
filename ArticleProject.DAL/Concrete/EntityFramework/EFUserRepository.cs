using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.DAL.Concrete.EntityFramework
{
    using Abstract;
    using Core.DAL.EntityFramework;
    using Core.Entities.Concrete;
    using Context;

    public class EFUserRepository : EFEntityRepositoryBase<User, ArticleContext>, IUserRepository
    {

    }
}
