using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Entities.DTOS
{
    using Core.Entities.Abstract;

    public class UserForLoginDTO : IDTOS
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
