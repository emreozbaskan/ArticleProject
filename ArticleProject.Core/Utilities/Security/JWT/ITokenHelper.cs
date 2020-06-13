using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Core.Utilities.Security.JWT
{
    using Core.Entities.Concrete;
    public interface ITokenHelper
    {
        AccessToken CreateToken(UserAccount user);
    }
}
