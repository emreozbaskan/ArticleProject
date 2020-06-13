
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace ArticleProject.Core.Utilities.Security.JWT
{
    using Entities.Concrete;
    using Encyription;
    using Extensions;

    public class JWTHelper: ITokenHelper
    {
        public IConfiguration Configuration { get; private set; }
        private TokenOptions _tokenOptions;
        private DateTime _AccessTokenExpression;

        public JWTHelper(IConfiguration configuration)
        {
            this.Configuration = configuration;
            //Configuration içinden Token Options içinden okuma işlemi gerçekleştirdik
            this._tokenOptions = this.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public AccessToken CreateToken(UserAccount user)
        {
            this._AccessTokenExpression = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var mySecurityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var mySigningCreadentials = SigningCredentionalsHelper.CreateSigningCredentials(mySecurityKey);
            var myJwt = CreateJwtSecurityToken(_tokenOptions, user, mySigningCreadentials);
            var myJwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var myToken = myJwtSecurityTokenHandler.WriteToken(myJwt);
            return new AccessToken() { Token = myToken, Expiration = _AccessTokenExpression };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, UserAccount user, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _AccessTokenExpression,
                notBefore: DateTime.Now,
                claims: SetClaims(user),
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        public IEnumerable<Claim> SetClaims(UserAccount user)
        {
            var myClaims = new List<Claim>();
            myClaims.AddEmail(user.Email);
            myClaims.AddName($"{user.FirstName} {user.LastName}");
            return myClaims;
        }
    }
}
