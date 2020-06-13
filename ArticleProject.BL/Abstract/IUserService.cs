
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.BL.Abstract
{
    using Core.Entities.Concrete;
    public interface IUserService
    {
        void Add(UserAccount user);
        UserAccount GetByMail(string email);
    }
}
