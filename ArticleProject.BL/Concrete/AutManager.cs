using ArticleProject.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.BL.Concrete
{
    using Core.Utilities.Result;
    using Core.Entities.Concrete;
    using Core.Utilities.Security.JWT;
    using Contants;
    using Entities.DTOS;
    using Core.Utilities.Security.Hashing;

    public class AutManager : IAutService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AutManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(UserAccount user)
        {
            var myAccessToken = _tokenHelper.CreateToken(user);
            return new SuccessDataResult<AccessToken>(myAccessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<UserAccount> Login(UserForLoginDTO userForLoginDTO)
        {
            var myUserToCheck = _userService.GetByMail(userForLoginDTO.Email);
            if (myUserToCheck == null)
                return new ErrorDataResult<UserAccount>(Messages.UserNotFound);

            if (!HashingHelper.VerifyPasswordHash(userForLoginDTO.Password, myUserToCheck.PasswordHash, myUserToCheck.PasswordSalt))
            {
                return new ErrorDataResult<UserAccount>(Messages.PasswordError);
            }
            return new SuccessDataResult<UserAccount>(myUserToCheck, Messages.SuccessFullLogin);
        }

        public IDataResult<UserAccount> Register(UserForRegisterDTO userForRegisterDTO, string password)
        {
            byte[] PasswordHash, PasswordSalt;
            HashingHelper.CreatePasswordHash(password, out PasswordHash, out PasswordSalt);
            var user = new UserAccount()
            {
                Email = userForRegisterDTO.Email,
                FirstName = userForRegisterDTO.FirstName,
                LastName = userForRegisterDTO.LastName,
                PasswordHash = PasswordHash,
                PasswordSalt = PasswordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<UserAccount>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExits);
            }
            return new SuccessResult();
        }
    }
}
