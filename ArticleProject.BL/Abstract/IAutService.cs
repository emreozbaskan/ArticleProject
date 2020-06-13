using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.BL.Abstract
{
    using Core.Utilities.Result;
    using Core.Entities;
    using Core.Entities.Concrete;
    using Entities.DTOS;
    using Core.Utilities.Security.JWT;

    public interface IAutService
    {
        IDataResult<UserAccount> Register(UserForRegisterDTO userForRegisterDTO, string password);
        IDataResult<UserAccount> Login(UserForLoginDTO userForLoginDTO);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(UserAccount user);
    }
}
